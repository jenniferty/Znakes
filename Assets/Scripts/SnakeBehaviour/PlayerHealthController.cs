using System.Data.SqlTypes;
using System.Runtime.Serialization.Formatters;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    // Settings
    private int health;

    private int maxHealth;

    public PlayerHealth playerHealth;

    public HealthBar healthBar;
    public shaker cam;

    public Boolean ignoreDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth =
            GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        setMaxHealth();
        setInitialBodyHealth();
        healthBar.SetHealth(getHealth());
        cam = GameObject.Find("Third Person Camera").GetComponent<shaker>();
    }

    // Update is called once per frame
    void Update()
    {
        // Health and Death
        setHealth(playerHealth.getSnakeHealth());
        healthBar.SetHealth(getHealth());
        CheckDeath();
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("TakeDamage");
        setHealth(getHealth() - damage);
        healthBar.SetHealth(getHealth());
    }

    private void CheckDeath()
    {
        if (getHealth() <= 0)
        {
            SceneChanger.LoadScene("DeadMenu");
            FindObjectOfType<AudioManager>().Stop("GameTheme");
            FindObjectOfType<AudioManager>().Play("MenuTheme");
        }
    }
    //sets health to be the same as head
    public void setInitialBodyHealth()
    {
        this.health = playerHealth.getSnakeHealth();
    }
    public int getHealth()
    {
        return health;
    }
    public void setHealth(int health)
    {
        this.health = health;
        playerHealth.setSnakeHealth(health);
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void setMaxHealth()
    {
        this.maxHealth = playerHealth.getSnakeMaxHealth();
    }
}
