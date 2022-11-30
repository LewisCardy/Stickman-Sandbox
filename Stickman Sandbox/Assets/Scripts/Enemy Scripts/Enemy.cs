using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 0f;
    public float enemyMaxHealth;
    public float enemyMinHealth = 0f;
    public float enemyDamage;
    bool hasDied = false;
    public Transform enemySpawnPoint;


    public EnemyHealthBar enemyHealthBar;
    void Start()
    {
        enemyHealth = enemyMaxHealth;
        enemyHealthBar.SetMaxEnemyHealth(enemyMaxHealth);
        enemyHealthBar.SetEnemyHealth(enemyMaxHealth);
        SetRigidBodyState(true);
        SetColliderState(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.SetEnemyHealth(enemyHealth);
        if (enemyHealth <= enemyMinHealth){
            enemyHealth = 0;
        }
        if (enemyHealth == 0){
            EnemyDeath();
        }
        Debug.Log(enemyHealth);
    }

    void EnemyDeath(){
        GetComponent<Animator>().enabled = false;
        SetRigidBodyState(false);
        SetColliderState(true);
        Destroy(gameObject, 2f);
    }

    void SetRigidBodyState(bool state){
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in rigidbodies){
            rigidbody.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }
    void SetColliderState(bool state){
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach(Collider collider in colliders){
            collider.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
    void EnemyRespawn(){
        if(hasDied == true){
            hasDied = false;
            enemyMaxHealth = enemyMaxHealth * 0.25f;
            enemyHealthBar.SetMaxEnemyHealth(enemyMaxHealth);
            enemyHealth = enemyMaxHealth;
            enemyDamage = enemyDamage * 0.25f;
            GetComponent<Animator>().enabled = true;
            SetColliderState(true);
            SetRigidBodyState(false);
        }
    }
    IEnumerator EnemyRespawnDelay(){
        yield return new WaitForSeconds(2);
        Instantiate(gameObject, enemySpawnPoint, true);
    }
}
