using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The enemy attack script
public class EnemyAttack : MonoBehaviour
{
    Animator animator;
    public float attackCooldown = 1.0f;
    private bool readyToAttack;
    //private bool isAttacking;

    void Start()
    {
        //gets the animator component
        animator = GetComponent<Animator>();
        readyToAttack = true;
    }

    void Update()
    {
        //checks for attack input each frame
        AttackInput();
    }

    //the enemy randomly attacks
    void AttackInput(){
        //picks a random number and depending on the number it will perform an attack
       int randomNumber = Random.Range(1, 4); 
        if (randomNumber == 1 && readyToAttack){
            readyToAttack = false;
            //isAttacking = true;
            LightAttack();
            Invoke(nameof(ResetAttack), attackCooldown); //cooldown of the attack so that the enemy attacks every second
        } else if (randomNumber == 2 && readyToAttack){
            readyToAttack = false;
            //isAttacking = true;
            HeavyAttack();
            Invoke(nameof(ResetAttack), attackCooldown);
        } else if (randomNumber == 3 && readyToAttack){
            readyToAttack = false;
            //isAttacking = true;
            Kick();
            Invoke(nameof(ResetAttack), attackCooldown);
        }
        

    }
    //animations for the various attacks
    void LightAttack(){
        animator.SetTrigger("Jab");
    }

    void HeavyAttack(){
        animator.SetTrigger("Cross"); 
    }

    void Kick(){
        animator.SetTrigger("Kick"); 
    }
    void ResetAttack(){
        readyToAttack = true;
    }
}
