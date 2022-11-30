using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerHealth = 0f;
    public float playerMaxHealth;
    public float playerMinHealth = 0f;
    public float playerDamage;

    public PlayerHealthBar playerHealthBar;
    void Start()
    {
        playerHealth = playerMaxHealth;
        playerHealthBar.SetMaxPlayerHealth(playerMaxHealth);
        playerHealthBar.SetPlayerHealth(playerMaxHealth);
        Debug.Log(playerHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.SetPlayerHealth(playerHealth);
        if (playerHealth == playerMinHealth){
            playerHealth = 0;
        }
    }
}
