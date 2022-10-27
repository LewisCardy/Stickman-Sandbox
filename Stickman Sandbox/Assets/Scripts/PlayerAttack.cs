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
        if (Input.GetKeyDown(KeyCode.J)){
            lightAttack();
        } else if (Input.GetKeyDown(KeyCode.K)){
            heavyAttack();
        }
    }
    void lightAttack(){
        animator.SetTrigger("Jab");
    }

    void heavyAttack(){
        animator.SetTrigger("Cross"); 
    }

}
