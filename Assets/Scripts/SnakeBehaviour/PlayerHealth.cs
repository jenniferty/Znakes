using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    // Settings
    private int snakeHealth;
    private int snakeMaxHealth = 100;
    public PlayerHealth playerHealthInstance;

    void Start()
    {
        setSnakeHealth(getSnakeMaxHealth());
    }
    void Awake()
    {
        // Remove duplicate instances
        if (playerHealthInstance == null)
        {
            playerHealthInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Keep same manager instance when scenes change
        DontDestroyOnLoad(gameObject);
    }

    public int getSnakeHealth()
    {
        return snakeHealth;
    }
    public void setSnakeHealth(int snakeHealth)
    {
        this.snakeHealth = snakeHealth;
    }
    public int getSnakeMaxHealth()
    {
        return snakeMaxHealth;
    }
    public void setSnakeMaxHealth(int snakeMaxHealth)
    {
        this.snakeMaxHealth = snakeMaxHealth;
    }
}