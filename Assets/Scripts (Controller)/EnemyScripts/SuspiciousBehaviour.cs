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
        //suspiciousHealthController = GameObject.Find("SuspiciousHealth").GetComponent<SuspiciousHealthController>();
        target = GameObject.Find("Target Camera").GetComponent<Camera>();
        //eSize = player.GetComponent<PlayerController>().size;
    }

    void Update()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
        if (enemy == enabled)
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
        if (other.gameObject.tag=="Player" && enemyHealthController.getEdible())
        {
            Destroy(gameObject);
        }
    }
}
