using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
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

    void DetectCollision(){
        //create a sphere at position on the collision layer
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0){
            
            gameObject.SetActive(false);

            Instantiate(hitFx, transform.position, Quaternion.identity);
            hitSfx.PlayOneShot(hitSfx.clip);

            if(isPlayer){
                enemy.enemyHealth -= player.playerDamage;
            } else if (isEnemy){
                player.playerHealth -= enemy.enemyDamage;
            }
        }
        
    }
}
