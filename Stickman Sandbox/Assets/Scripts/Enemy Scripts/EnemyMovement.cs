using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //enemy follow script
    //example from the labs
    public GameObject player;
    public float speed = 0.5f;
    void Update() {

        // lerp function
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
    public void OnTriggerEnter(Collider other) {
        Debug.Log("Hit " + other.name);
    }
}
