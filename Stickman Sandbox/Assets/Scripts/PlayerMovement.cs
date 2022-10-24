using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;

    public float speed = 6f;

    float horizontalInput;

    Vector3 moveDirection;
    
    public float groundDrag;
    //Ground Check
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    public KeyCode jump = KeyCode.Space;

    Rigidbody rb;
    public Transform orientation;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate(){
        Movement();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);
        MyInput();
        if (horizontalInput > 0 || horizontalInput < 0){
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }
        if (grounded){
            rb.drag = groundDrag;
            animator.SetBool("isJumping", false);
        } else {
            
            animator.SetBool("isJumping", true);
            rb.drag = 0;
        }
        SpeedControl();
    }


    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        

        if (Input.GetKey(jump) && readyToJump && grounded){
            readyToJump = false;
            Jump();
            animator.SetBool("isJumping", true);
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void Movement(){
        moveDirection = orientation.right * horizontalInput;

        if (grounded){
            rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
            
        } else if (!grounded){
            rb.AddForce(moveDirection.normalized * speed * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        if (flatVel.magnitude > speed) {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump(){
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump(){
        readyToJump = true;
    }
} 
