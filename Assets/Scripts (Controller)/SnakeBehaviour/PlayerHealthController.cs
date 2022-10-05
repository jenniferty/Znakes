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
    //public LoseScreen loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("PlayerHealth").GetComponent<PlayerHealth>();
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        //loseScreen = GameObject.Find("LoseScreen").GetComponent<LoseScreen>();
        setMaxHealth();
        setInitialBodyHealth();
        healthBar.SetHealth(getHealth());
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
        playerHealth.setSnakeHealth(getHealth() - damage);
        //setHealth(getHealth() - damage);
        healthBar.SetHealth(getHealth());
    }
    private void CheckDeath()
    {
        if (getHealth() <= 0)
        {
            //PauseGame.Pause();
            //loseScreen.ShowDeathScreen();
            SceneManager.LoadScene(2);
        }
    }

    public int getHealth()
    {
        return health;
    }
    public void setInitialBodyHealth()
    {
        this.health = playerHealth.getSnakeHealth();
    }
    public void setHealth(int health)
    {
        this.health = health;
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
