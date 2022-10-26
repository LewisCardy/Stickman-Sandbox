using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator; //animator

    public float speed = 6f; //movement speed

    float horizontalInput; //horizontal keyboard input

    Vector3 moveDirection; //move direction co ordinates
    
    public float groundDrag; //drag
    //Ground Check
    public float playerHeight; //player height
    public LayerMask Ground; //ground layer mask
    bool grounded; //if grounded

    public KeyCode jump = KeyCode.Space; //spacebar keycode for jump

    Rigidbody rb; //the rigidbody of the player
    public Transform orientation; //orientation of the player

    public float jumpForce; //force of jump
    public float jumpCooldown; //cooldown jump
    public float airMultiplier; //air speed multiplier
    bool readyToJump; //if ready to jump

    private bool isJumping; //if jumping




    private void Start() {
        //gets the rigidbody for the object and freezes the rotation
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
        readyToJump = true;
        animator = GetComponent<Animator>(); // the animator component of the object
    }
    
    private void FixedUpdate(){
        Movement();
    }

    void Update() //updates every frame
    {
        //creates a beam half the length of the player and if it touches an object with ground layer then the player is touching the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);
        MyInput();
        if (horizontalInput > 0 || horizontalInput < 0){
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }
        Debug.Log(grounded);
        if (grounded == true){
            rb.drag = groundDrag; //apply drag if ghrounded

            //sets the animator to grounded and the rest to false when on the ground
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        } else {
            //animator not grounded
            animator.SetBool("isGrounded", false);
            //if the y velocity is higher than 0 then jumping animation
            if (rb.velocity.y > 0){
                animator.SetBool("isJumping", true);
            }
            //if player is jumping and going down then fall animation
            if ((isJumping && rb.velocity.y < 0) || rb.velocity.y < -2){
                animator.SetBool("isFalling", true);
            }
            //0 drag in midair
            rb.drag = 0;
        }
        SpeedControl();
    }


    private void MyInput(){ //the keyboard inputs
        horizontalInput = Input.GetAxisRaw("Horizontal"); //hoprizontal keyboard input
        
        //if jumped and grounded and ready to jump then jump then reset jump
        if (Input.GetKey(jump) && readyToJump && grounded){
            readyToJump = false;
            isJumping = true;
            Jump();
            
            
            Invoke(nameof(ResetJump), jumpCooldown);
        }


    }

    private void Movement(){ //moves the player
        moveDirection = orientation.right * horizontalInput; //calculates move direction

        if (grounded){ //if on the ground move in the direction with the speed of the player
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
            
        } else if (!grounded){ //if not on the ground move with direction but with an added multiplier to move faster in the air
            rb.AddForce(moveDirection.normalized * speed * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl(){ //limits the players speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.y); //flat velocity of movement
        if (flatVel.magnitude > speed) { //if moving faster than movespeed value then make a limited velocity making miove speed the maximum speed
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump(){ //jumping
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); //reset y velocity

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); //adds the juming force upwards on the y once.

    }

    private void ResetJump(){ //resets jump
        readyToJump = true;
        
    }
} 
