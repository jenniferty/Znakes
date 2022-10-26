using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{

    //not used anymore
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
            //playerSnake.GrowSnake();
            FindObjectOfType<AudioManager>().Play("Food");
        }





    }

    // Update is called once per frame
    void Update()
    {

    }
}
