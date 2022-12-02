using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //the attack script
    public Player player;
    public Enemy enemy;

    public LayerMask collisionLayer;
    public float radius = 0.25f;
    public float damage = 2f;

    public bool isPlayer, isEnemy;

    public GameObject hitFx;
    public AudioSource hitSfx;
    private bool playerHit;
    private bool enemyHit;

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision(){ //the detection of collision
        //create a sphere at position on the collision layer
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer); //create a sphere at the attack point

        if (hit.Length > 0){ //if theres a hit
            
            gameObject.SetActive(false); //deactivate the attack point

            Instantiate(hitFx, transform.position, Quaternion.identity); //create the hit fx
            hitSfx.PlayOneShot(hitSfx.clip); //play hit sound

            if(isPlayer){ //if attack comes from player
                enemy.enemyHealth -= player.playerDamage; //reduce enemy health by player damage
            } else if (isEnemy){ //if attack comes from enemy
                player.playerHealth -= enemy.enemyDamage; //reduce player health by enemy damage
            }
        }
        
    }
}
