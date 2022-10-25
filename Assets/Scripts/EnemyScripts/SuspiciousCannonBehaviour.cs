using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspiciousCannonBehaviour : MonoBehaviour
{
    public GameObject enemy;
    public EnemyHealthController enemyHealthController;
    public PlayerController playerController;
    private bool destroyed = false;
    //public Camera target;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthController = GetComponent<EnemyHealthController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //target = GameObject.Find("Target Camera").GetComponent<Camera>();
        if (enemy == enabled)
        {
            Invoke("TimeOut", 15);
        }
    }

    void Update()
    {
        //transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
        if(enemyHealthController.getEdible())
        {
            enemy.transform.Find("InedibleIcon").gameObject.SetActive(false);
            enemy.transform.Find("EdibleIcon").gameObject.SetActive(true);
        }
        if(checkDestroyed())
        {
            CancelInvoke("TimeOut");
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
            playerController.GrowSnake();
        }
    }
    public void setDestroyed()
    {
        this.destroyed = true;
    }
    public bool checkDestroyed()
    {
        return this.destroyed;
    }
}
