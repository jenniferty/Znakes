using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject healthPack;
    public int healAmount = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPack == enabled)
        {
            Invoke("TimeOut", 3);
        }
    }

    void TimeOut()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other){
        if (other.gameObject.tag=="Player"){
            Heal(healAmount, other);
        }
    }

    public void Heal(int healAmount, Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            if (player.health > (player.maxHealth - healAmount))
            {
                player.health = player.maxHealth;
            }else{
                player.health = player.health + healAmount;
            }
            Destroy(gameObject);
        }
    }
}
