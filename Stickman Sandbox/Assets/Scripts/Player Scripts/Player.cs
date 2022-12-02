using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//the script for the player containing its health, damage and the states
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
        //sets the max and current values of the healthbars
        playerHealthBar.SetMaxPlayerHealth(playerMaxHealth);
        playerHealthBar.SetPlayerHealth(playerMaxHealth);

        deathScreen.SetActive(false);
        enemySpawner.SetActive(false);
        enemyKillCount = 0;
        spawnInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.SetPlayerHealth(playerHealth); //player healthbar values
        if (playerHealth <= playerMinHealth){ //if the player goes below the minium make the health 0
            playerHealth = 0;
        }
        if (playerHealth == 0){ //if the player dies show deathscreen and pause the game
            gameManager.PlayerDeath();
            deathScreen.SetActive(true);
        }

        if (enemy.enemyHealth == 0){ //if enemy dies
            //activate the spawner and help text
            spawnInfo.SetActive(true);
            enemySpawner.SetActive(true);

            if(!enemyKilled){ //makes sure that the score only increses by 1 every kill
                gameManager.Score();
                enemyKilled = true;
            }
            
        } else { //if the enemy is alive deactivate the spawner
            spawnInfo.SetActive(false);
            enemySpawner.SetActive(false);
            enemyKilled = false;
        }

    }

    void OnTriggerEnter(Collider collider){ //on trigger with the enemy spawn
        if(collider.tag == "EnemySpawn"){
            enemy.EnemyRespawn(); //spawn another enemy
        }
    }

}
