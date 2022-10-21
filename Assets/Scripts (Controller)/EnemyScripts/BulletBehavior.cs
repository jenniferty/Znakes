using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private int damageMultiplier;
    public PlayerController playerController;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Debug.Log(playerController.getBodyCount());
        setDamageMultiplier(1);
        Destroy(gameObject, 4f);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Sides"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealthController enemyHealth = collision.gameObject.GetComponent<EnemyHealthController>();
            enemyHealth.TakeDamage(playerController.getBodyCount() * getDamageMultiplier());
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Bomb"))
        {
            Explosion bomb = collision.gameObject.GetComponent<Explosion>();
            bomb.Detonate();
            Destroy(gameObject);
        }
    }
    public int getDamageMultiplier()
    {
        return damageMultiplier;
    }
    public void setDamageMultiplier(int damageMultiplier)
    {
        this.damageMultiplier = damageMultiplier;
    }
}
