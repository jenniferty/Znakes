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
<<<<<<< HEAD:Assets/Scripts/SnakeBehaviour/PlayerHealthController.cs
=======

>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts (Controller)/SnakeBehaviour/PlayerHealthController.cs

    // Start is called before the first frame update
    void Start()
    {
        playerHealth =
            GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        setMaxHealth();
        setInitialBodyHealth();
        healthBar.SetHealth(getHealth());
<<<<<<< HEAD:Assets/Scripts/SnakeBehaviour/PlayerHealthController.cs
        cam = GameObject.Find("Third Person Camera").GetComponent<shaker>();
=======
        cam = GameObject.Find("THird Person Camera").GetComponent<shaker>();
>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts (Controller)/SnakeBehaviour/PlayerHealthController.cs
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
        Debug.Log(getHealth());
        cam.shouldShake = true;
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
<<<<<<< HEAD:Assets/Scripts/SnakeBehaviour/PlayerHealthController.cs
    //sets health to be the same as head
=======

    public int getHealth()
    {
        return health;
    }

>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts (Controller)/SnakeBehaviour/PlayerHealthController.cs
    public void setInitialBodyHealth()
    {
        this.health = playerHealth.getSnakeHealth();
    }
<<<<<<< HEAD:Assets/Scripts/SnakeBehaviour/PlayerHealthController.cs
    public int getHealth()
    {
        return health;
    }
=======

>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts (Controller)/SnakeBehaviour/PlayerHealthController.cs
    public void setHealth(int health)
    {
        this.health = health;
        playerHealth.setSnakeHealth (health);
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
