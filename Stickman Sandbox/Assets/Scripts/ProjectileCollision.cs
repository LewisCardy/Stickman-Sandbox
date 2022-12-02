using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    //when the throable cube hits an enemy
    public Enemy enemy;
    public GameObject hitFx;
    public AudioSource hitSfx;
    private GameObject effect;
    public float timer = 1.0f;
    float hit = 0.0f;
    void OnCollisionStay(Collision collision){ //if cube collides with something destroy
        hit += timer * Time.deltaTime; //a timer so it despawns after a set amount of time
        if (hit >= 0.6 ){
                gameObject.SetActive(false);  //de-activate
            }
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.layer == 9){
            enemy.enemyHealth -= 100;
            effect = Instantiate(hitFx, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            hitSfx.PlayOneShot(hitSfx.clip);
            gameObject.SetActive(false);
        }
    }

}

