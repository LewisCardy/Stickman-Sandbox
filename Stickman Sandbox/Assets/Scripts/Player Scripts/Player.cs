using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject deathScreen;
    public GameObject spawnInfo;

    public float playerHealth = 0f;
    public float playerMaxHealth;
    public float playerMinHealth = 0f;
    public float playerDamage;

    private bool enemyKilled;
    
    public int enemyKillCount = 0;
    public PlayerHealthBar playerHealthBar;
    public Enemy enemy;

    public GameObject enemySpawner;
    void Start()
    {
        playerHealth = playerMaxHealth;
        playerHealthBar.SetMaxPlayerHealth(playerMaxHealth);
        playerHealthBar.SetPlayerHealth(playerMaxHealth);
        Debug.Log(playerHealth);
        deathScreen.SetActive(false);
        enemySpawner.SetActive(false);
        enemyKillCount = 0;
        spawnInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.SetPlayerHealth(playerHealth);
        if (playerHealth <= playerMinHealth){
            playerHealth = 0;
        }
        if (playerHealth == 0){
            gameManager.PlayerDeath();
            deathScreen.SetActive(true);
        }

        if (enemy.enemyHealth == 0){
            spawnInfo.SetActive(true);
            enemySpawner.SetActive(true);
            if(!enemyKilled){
                gameManager.Score();
                enemyKilled = true;
            }
            
        } else {
            spawnInfo.SetActive(false);
            enemySpawner.SetActive(false);
            enemyKilled = false;
        }

    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "EnemySpawn"){
            enemy.EnemyRespawn();
        }
    }

}
