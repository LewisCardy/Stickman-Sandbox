using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The player attack script
public class EnemyAttack : MonoBehaviour
{
    Animator animator;

    private float time = 0.0f;
    public float attackCooldown = 1.0f;
    private bool readyToAttack;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        //gets the animator component
        animator = GetComponent<Animator>();
        readyToAttack = true;
    }


    // Update is called once per frame
    void Update()
    {
        //checks for attack input each frame
        AttackInput();
    }

    //checks for attack input
    void AttackInput(){
       int randomNumber = Random.Range(1, 4);
        if (randomNumber == 1 && readyToAttack){
            readyToAttack = false;
            isAttacking = true;
            LightAttack();
            Invoke(nameof(ResetAttack), attackCooldown);
        } else if (randomNumber == 2 && readyToAttack){
            readyToAttack = false;
            isAttacking = true;
            HeavyAttack();
            Invoke(nameof(ResetAttack), attackCooldown);
        } else if (randomNumber == 3 && readyToAttack){
            readyToAttack = false;
            isAttacking = true;
            Kick();
            Invoke(nameof(ResetAttack), attackCooldown);
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

    void Throw(){
        animator.SetTrigger("Throw");
    }
    void ResetAttack(){
        readyToAttack = true;
    }
}
