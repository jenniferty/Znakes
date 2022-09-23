using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    public FoodSpawnerScript foodSpawner;
    public PlayerController playerSnake;
    // PlayerController snakePlayer = new PlayerController();

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision ");
        //  snakePlayer.GrowSnake();

        if (collider.CompareTag("Food"))
        {

            foodSpawner.Spawn();
            Destroy(collider.gameObject);
            playerSnake.GrowSnake();
        }

        if (collider.CompareTag("Sides"))
        {
            //Destroy(playerSnake);
            playerSnake.GetComponent<PlayerController>().TakeDamage(100);
            Debug.Log("Has hit wall hope it fucken dies");
        }

        


    }

    // Update is called once per frame
    void Update()
    {

    }
}
