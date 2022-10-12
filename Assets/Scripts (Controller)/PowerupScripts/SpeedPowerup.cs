using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public GameObject speedPowerup;
    public GameObject player;
    private int speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speedPowerup == enabled)
        {
            Invoke("TimeOut", 10);
        }
    }

    void TimeOut()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MultiplySpeed(getSpeedMultiplier(), other);
        }
    }

    public void MultiplySpeed(int healAmount, Collider other)
    {
        // CHANGE TO SPEEDCONTROLLER
        PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
        if (playerHealth != null)
        {
            if (playerHealth.getHealth() > (playerHealth.getMaxHealth() - healAmount))
            {
                playerHealth.setHealth(playerHealth.getMaxHealth());
            }
            else
            {
                playerHealth.setHealth(playerHealth.getHealth() + healAmount);
            }
            Destroy(gameObject);
        }
    }
    public int getSpeedMultiplier()
    {
        return this.speedMultiplier;
    }
    public void setSpeedMultiplier(int speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }
}
