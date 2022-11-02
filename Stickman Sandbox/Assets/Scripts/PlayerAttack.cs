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
            LightAttack();
        } else if (Input.GetKeyDown(KeyCode.K)){
            HeavyAttack();
        } else if (Input.GetKeyDown(KeyCode.L)){
            Kick();
        }
    }
    void LightAttack(){
        animator.SetTrigger("Jab");
    }

    void HeavyAttack(){
        animator.SetTrigger("Cross"); 
    }

    void Kick(){
        animator.SetTrigger("Kick"); 
    }

}
