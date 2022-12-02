using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the script for the enemy containg the health, damage and respawn
public class Enemy : MonoBehaviour
{
    public float enemyHealth = 0f;
    public float enemyMaxHealth;
    public float enemyMinHealth = 0f;
    public float enemyDamage;
    public bool hasDied = false;
    public Transform enemySpawnPoint;
    public GameObject EnemyObject;


    public EnemyHealthBar enemyHealthBar;
    void Start()
    {   
        //sets the enemy health and healthbars
        enemyHealth = enemyMaxHealth;
        enemyHealthBar.SetMaxEnemyHealth(enemyMaxHealth);
        enemyHealthBar.SetEnemyHealth(enemyMaxHealth);

        //disables the ragdoll
        SetRigidBodyState(true);
        SetColliderState(false);

        hasDied = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.SetEnemyHealth(enemyHealth); //enemy health update
        if (enemyHealth <= enemyMinHealth){ //if the health is below 0 make it 0
            enemyHealth = 0;
        }
        if (enemyHealth == 0){ //if the enemy dies
            hasDied = true;
            EnemyDeath();
        }
        Debug.Log(enemyHealth);
    }

    //ragdoll the enemy and spawn another
    void EnemyDeath(){
        GetComponent<Animator>().enabled = false; //disable animator
        //ragdoll the enemy
        SetRigidBodyState(false);
        SetColliderState(true);
        //spawn another after a delay
        StartCoroutine(EnemyRespawnDelay());
    }
    //the enemy respawn
    public void EnemyRespawn(){
        //when the enemy dies reset its health and damage with a 0.25 multiplier
        enemyMaxHealth = enemyMaxHealth * 1.25f; 
        enemyHealthBar.SetMaxEnemyHealth(enemyMaxHealth);
        enemyHealth = enemyMaxHealth;
        enemyDamage = enemyDamage * 1.25f;

        //disable the ragdoll
        EnemyObject.GetComponent<Animator>().enabled = true;
        SetColliderState(true);
        SetRigidBodyState(false);

        //moves the object to the postion of the spawnpoint and activates it
        gameObject.transform.position = enemySpawnPoint.transform.position;
        gameObject.SetActive(true);
    }
    
    //a respawn delay
    IEnumerator EnemyRespawnDelay(){
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false); //deactivates the enemy to make it seem like it was deleted
    }
    //sets the rigidbody state
    void SetRigidBodyState(bool state){
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rigidbodies){
            rigidbody.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }

    //sets the collider state
    void SetColliderState(bool state){
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach(Collider collider in colliders){
            collider.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }

}
