using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 0f;
    public float enemyMaxHealth;
    public float enemyMinHealth = 0f;
    public float enemyDamage;

    public EnemyHealthBar enemyHealthBar;
    void Start()
    {
        enemyHealth = enemyMaxHealth;
        enemyHealthBar.SetMaxEnemyHealth(enemyMaxHealth);
        enemyHealthBar.SetEnemyHealth(enemyMaxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthBar.SetEnemyHealth(enemyHealth);
        if (enemyHealth == enemyMinHealth){
            enemyHealth = 0;
        }
    }
}
