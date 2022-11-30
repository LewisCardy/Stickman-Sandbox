using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject deathScreen;
    public float playerHealth = 0f;
    public float playerMaxHealth;
    public float playerMinHealth = 0f;
    public float playerDamage;

    private bool enemySpawned = false;
    
    public PlayerHealthBar playerHealthBar;
    void Start()
    {
        playerHealth = playerMaxHealth;
        playerHealthBar.SetMaxPlayerHealth(playerMaxHealth);
        playerHealthBar.SetPlayerHealth(playerMaxHealth);
        Debug.Log(playerHealth);
        deathScreen.SetActive(false);
        
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
    }

    void OnTriggerEnter(Collider collider){
        if(collider.tag == "EnemySpawner"){
            enemySpawned = true;
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.tag == "EnemySpawner"){
            enemySpawned = false;
        }
    }
}
