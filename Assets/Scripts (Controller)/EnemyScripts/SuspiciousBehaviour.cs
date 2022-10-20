using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspiciousBehaviour : MonoBehaviour
{
    public GameObject enemy;
    public EnemyHealthController enemyHealthController;
    public Camera target;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthController = GetComponent<EnemyHealthController>();
        target = GameObject.Find("Target Camera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
        if(enemyHealthController.getEdible())
        {
            enemy.transform.Find("FlameThrower").gameObject.SetActive(false);
        }
        if (enemy == enabled)
        {
            Invoke("TimeOut", 15);
        }
    }

    void TimeOut()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player" && enemyHealthController.getEdible())
        {
            Destroy(gameObject);
        }
    }
}
