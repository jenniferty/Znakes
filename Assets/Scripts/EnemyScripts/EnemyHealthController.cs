using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealthController : MonoBehaviour 
{
    // Settings
    private int health;
    private int maxHealth;
    private int edibleHealth;
    private int level;
    private bool isEdible = false;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        setLevel(playerController.getBodyCount());
        Debug.Log(getLevel());
        setMaxHealth();
        setHealth(getMaxHealth());
        Debug.Log(getMaxHealth());
        Debug.Log(getHealth());
        setEdibleHealth(getMaxHealth());
        Debug.Log(getEdibleHealth());
        Debug.Log(getEdible());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        setHealth(getHealth() - damage);
        CheckEdible();
        Debug.Log(getHealth());
    }
    public void CheckEdible()
    {
        if (getHealth() <= getEdibleHealth())
        {
            setEdible();
        }
    }

    public int getHealth()
    {
        return health;
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

        this.maxHealth = getLevel() * 10;
    }
    public bool getEdible()
    {
        return isEdible;
    }
    public void setEdible()
    {
        this.isEdible = true;
    }
    public int getEdibleHealth()
    {
        return edibleHealth;
    }
    public void setEdibleHealth(int maxhealth)
    {
        this.edibleHealth = (int)Mathf.Ceil(maxhealth/2);
    }
    public int getLevel()
    {
        return level;
    }
    public void setLevel(int playersize)
    {
        int minLevel;
        int maxLevel = playersize + 10;
        if((playersize - 5)<= 0)
        {
            minLevel = 1;
        }else{
            minLevel = playersize - 5;
        }
        this.level = Random.Range(minLevel, maxLevel);
    }
}