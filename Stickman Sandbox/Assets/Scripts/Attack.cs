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

            // if(isPlayer){
            //     Vector3 hitFxPos = hit[0].transform.position;
            //     hitFxPos.y += 1.3f;

            //     if(hit[0].transform.forward.x > 0){
            //         hitFxPos.x += 0.3f;
            //     } else if(hit[0].transform.forward.x < 0){
            //         hitFxPos.x -= 0.3f;
            //     }
            //     Instantiate(hitFx, hitFxPos, Quaternion.identity);
            // }
            if(isPlayer){
                enemy.enemyHealth -= enemy.enemyDamage;
            } else if (isEnemy){
                player.playerHealth -= player.playerDamage;
            }
        }
        
    }
}
