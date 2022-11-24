using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public float timer = 1.0f;
    float hit = 0.0f;
    void OnCollisionStay(Collision collision){ //if cube collides with something destroy
        
        hit += timer * Time.deltaTime; //a timer so it despawns after a set amount of time

        if (collision.gameObject.layer == 9){ //if hits an enemy
            

            //deal damage here

            if (hit >= 0.3 ){ //if colliding for a while
                Destroy(gameObject);
            }
        }
        if (hit >= 0.3 ){
                Destroy(gameObject);  //destroy itself
            }
    }

}
