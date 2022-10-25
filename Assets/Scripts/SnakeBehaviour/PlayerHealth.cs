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
<<<<<<< HEAD:Assets/Scripts/SnakeBehaviour/PlayerHealth.cs
        //For manipulating maxhealth when difficulty changes
=======
>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts (Controller)/SnakeBehaviour/PlayerHealth.cs
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