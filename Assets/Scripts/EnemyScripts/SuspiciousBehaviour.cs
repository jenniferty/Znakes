using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspiciousBehaviour : MonoBehaviour
{
    public GameObject enemy;
    public EnemyHealthController enemyHealthController;
    public PlayerController playerController;
    public ScoreSystemDisplay scoreDisplay;
    //public Camera target;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthController = GetComponent<EnemyHealthController>();
        scoreDisplay = GameObject.Find("Score").GetComponent<ScoreSystemDisplay>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (enemy == enabled)
        {
            Invoke("TimeOut", 15);
        }
    }

    void Update()
    {
        if(enemyHealthController.getEdible())
        {
            enemy.transform.Find("InedibleIcon").gameObject.SetActive(false);
            enemy.transform.Find("EdibleIcon").gameObject.SetActive(true);
        }
        if(enemyHealthController.getHealth() <= 0)
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
            FindObjectOfType<AudioManager>().Play("Food");
            Destroy(gameObject);
            playerController.GrowSnake();
            scoreDisplay.addScore(100);
        }
    }
}
