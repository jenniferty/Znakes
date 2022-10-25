using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspiciousCannonBehaviour : MonoBehaviour
{
    public GameObject enemy;
    public EnemyHealthController enemyHealthController;
    public PlayerController playerController;
<<<<<<< HEAD:Assets/Scripts/EnemyScripts/SuspiciousCannonBehaviour.cs
    private bool destroyed = false;
=======
    //public Camera target;
>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts/EnemyScripts/SuspiciousBehaviour.cs
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthController = GetComponent<EnemyHealthController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
<<<<<<< HEAD:Assets/Scripts/EnemyScripts/SuspiciousCannonBehaviour.cs
=======
        //target = GameObject.Find("Target Camera").GetComponent<Camera>();
>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts/EnemyScripts/SuspiciousBehaviour.cs
        if (enemy == enabled)
        {
            Invoke("TimeOut", 15);
        }
    }

    void Update()
    {
<<<<<<< HEAD:Assets/Scripts/EnemyScripts/SuspiciousCannonBehaviour.cs
=======
        //transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts/EnemyScripts/SuspiciousBehaviour.cs
        if(enemyHealthController.getEdible())
        {
            enemy.transform.Find("InedibleIcon").gameObject.SetActive(false);
            enemy.transform.Find("EdibleIcon").gameObject.SetActive(true);
<<<<<<< HEAD:Assets/Scripts/EnemyScripts/SuspiciousCannonBehaviour.cs
=======
            enemy.transform.Find("FlameThrower").gameObject.SetActive(false);
>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70:Assets/Scripts/EnemyScripts/SuspiciousBehaviour.cs
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
