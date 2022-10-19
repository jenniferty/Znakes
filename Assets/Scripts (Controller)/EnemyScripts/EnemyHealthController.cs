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
    private bool isEdible = false;
    public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        setHealth(getMaxHealth());
        setEdibleHealth(getMaxHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        setHealth(getHealth() - damage);
        CheckEdible();
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
        this.maxHealth = enemyHealth.maxHealth;
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
        //int eHealth = (int)Mathf.Ceil(maxhealth/2);
        this.edibleHealth = (int)Mathf.Ceil(maxhealth/2);
    }

}