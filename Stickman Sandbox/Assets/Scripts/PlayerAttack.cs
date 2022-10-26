using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The player attack script
public class PlayerAttack : MonoBehaviour
{
     Animator animator;

    private float timeBetweenPunches = 0.0f;
    private float timeStamp;
    public static float time;
    public float timeLastPass = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //gets the animator component
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //checks for attack input each frame
        AttackInput();
    }

    //checks for attack input
    void AttackInput(){
        //when E is pressed
        if (Input.GetKeyDown(KeyCode.E)){
            Attack();
            
            //current game time
            time = Time.time;
            //time since button press
            float deltaTime = time - timeLastPass;
            
            //checks to see if e was pressed more than once in a certain amount of time
            if (deltaTime > 5.0f){
                //if the key was pressed more than once cross animation after jab
                timeLastPass = time;
                animator.SetTrigger("Cross"); 
            } else {
                //jab animation if pressed once
                animator.SetTrigger("Jab");
            }
            
        }
    }
    void Attack(){

    }

}
