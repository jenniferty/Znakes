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
        //Debug.Log("collision ");
        //  snakePlayer.GrowSnake();

        if (collider.CompareTag("Food"))
        {

            foodSpawner.Spawn();
          

            Destroy(collider.gameObject);
            playerSnake.GrowSnake();
            FindObjectOfType<AudioManager>().Play("Food");
        }

        if (collider.CompareTag("Sides"))
        {
            //Destroy(playerSnake);
            playerSnake.GetComponent<PlayerHealthController>().TakeDamage(100);
            Debug.Log("Has hit wall");
        }

        if (collider.CompareTag("BodySides"))
        {
            //Destroy(playerSnake);
            playerSnake.GetComponent<PlayerHealthController>().TakeDamage(100);
            Debug.Log("has hit its own body");
        }




    }

    // Update is called once per frame
    void Update()
    {

    }
}
