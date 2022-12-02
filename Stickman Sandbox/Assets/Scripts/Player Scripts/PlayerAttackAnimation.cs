using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The player attack script
public class PlayerAttackAnimation : MonoBehaviour
{
    Animator animator;
    

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
        //when the key is pressed perform the corrisponding attack
        if (Input.GetKeyDown(KeyCode.J)){
            LightAttack();
        } else if (Input.GetKeyDown(KeyCode.K)){
            HeavyAttack();
        } else if (Input.GetKeyDown(KeyCode.L)){
            Kick();
        } else if (Input.GetKeyDown(KeyCode.F)){
            Throw();
        }
    }

    //animations for the attacks
    void LightAttack(){
        animator.SetTrigger("Jab");
    }

    void HeavyAttack(){
        animator.SetTrigger("Cross"); 
    }

    void Kick(){
        animator.SetTrigger("Kick"); 
    }

    void Throw(){
        animator.SetTrigger("Throw");
    }
}
