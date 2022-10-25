using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private int damageMultiplier;//for damage powerup to be implemented
    public PlayerController playerController;//to grab bodycount for damage calculation
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        setDamageMultiplier(3);
        Destroy(gameObject, 4f);//if bullet misses
    }

    public void OnTriggerEnter(Collider collision)
    {
        //destroys itself when hits obstacles
        if (collision.gameObject.CompareTag("Sides"))
        {
            Destroy(gameObject);
        }
        //decrease health of enemy on contact
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealthController enemyHealth = collision.gameObject.GetComponent<EnemyHealthController>();
            enemyHealth.TakeDamage(playerController.getBodyCount() * getDamageMultiplier());
            Destroy(gameObject);
        }
        //increase hit counter of cannon
        if (collision.gameObject.CompareTag("Cannon"))
        {
            CannonHealth cannonHealth = collision.gameObject.GetComponent<CannonHealth>();
            cannonHealth.TakeHit();
            Destroy(gameObject);
        }
        //destroys bomb
        if (collision.gameObject.CompareTag("Bomb"))
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
