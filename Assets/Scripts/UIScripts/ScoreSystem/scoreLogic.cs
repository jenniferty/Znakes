using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreLogic : MonoBehaviour
{
    public ScoreSystemDisplay scoreDisplay;

    public PlayerController playerSnake;

    void Start()
    {
        scoreDisplay = GameObject.Find("Score").GetComponent<ScoreSystemDisplay>();   
    }
     
    // Start is called before the first frame update
    //private void OnTriggerEnter(Collider other)
    //{

    //    //add if else statements as each different food type will have different points 

    //    scoreDisplay.addScore(50);
    //    //scoreText.SetText("Score: " + score);
    //}

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("collision ");
        //  snakePlayer.GrowSnake();


        //food
        if (collider.CompareTag("Food"))
        {
            Destroy(collider.gameObject);
            playerSnake.GrowSnake();
            FindObjectOfType<AudioManager>().Play("Food");
            scoreDisplay.addScore(10);
        }

        //alien
        if (collider.CompareTag("alien"))
        {
            Destroy(collider.gameObject);
            playerSnake.GrowSnake();
            FindObjectOfType<AudioManager>().Play("Food");
            scoreDisplay.addScore(20);
        }

        //baby
        if (collider.CompareTag("baby"))
        {
            Destroy(collider.gameObject);
            playerSnake.GrowSnake();
            FindObjectOfType<AudioManager>().Play("Food");
            scoreDisplay.addScore(50);
        }

        //turtle
        if (collider.CompareTag("turtle"))
        {
            Destroy(collider.gameObject);
            playerSnake.GrowSnake();
            FindObjectOfType<AudioManager>().Play("Food");
            scoreDisplay.addScore(40);
        }

        //rat(squirrel)
        if (collider.CompareTag("rat"))
        {
            Destroy(collider.gameObject);
            playerSnake.GrowSnake();
            FindObjectOfType<AudioManager>().Play("Food");
            scoreDisplay.addScore(30);
        }


        //player dies if iit eats itself
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
}
