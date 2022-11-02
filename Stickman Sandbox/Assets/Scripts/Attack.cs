using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer, isEnemy;

    public GameObject hitFx;

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision(){
        //create a sphere at position on the collision layer
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0){
            Debug.Log("ENEMY HIT");
        }
    }
}
