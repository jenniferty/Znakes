using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject healthPack;
    public GameObject player;
    private int healAmount;
    void Start()
    {
        setHealAmount(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPack == enabled)
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
            Heal(getHealAmount(), other);
            FindObjectOfType<AudioManager>().Play("Health");
        }
    }

    public void Heal(int healAmount, Collider other)
    {
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
    public int getHealAmount()
    {
        return this.healAmount;
    }
    public void setHealAmount(int healAmount)
    {
        this.healAmount = healAmount;
    }
}
