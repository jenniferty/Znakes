using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    // Settings
    private int snakeHealth;
    private int snakeMaxHealth = 100;

    // Start is called before the first frame update
    /*public PlayerHealth(int health)
    {
        setSnakeMaxHealth(health);
        setSnakeHealth(getSnakeMaxHealth());
    }*/
    void Start()
    {
        setSnakeHealth(getSnakeMaxHealth());
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