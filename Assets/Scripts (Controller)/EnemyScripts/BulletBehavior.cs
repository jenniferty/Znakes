using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Sides"))
        {
            Destroy(gameObject);
        }
        EnemyHealthController enemyHealth = collision.GetComponent<EnemyHealthController>();
        if (enemyHealth != null)
        {
            enemyHealth.GetComponent<EnemyHealthController>().TakeDamage(5);
        }
    }
}
