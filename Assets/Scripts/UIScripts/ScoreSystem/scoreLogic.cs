using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreLogic : MonoBehaviour
{
    public ScoreSystemDisplay scoreDisplay;
    void Start()
    {
        scoreDisplay = GameObject.Find("Score").GetComponent<ScoreSystemDisplay>();   
    }
     
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        //add if else statements as each different food type will have different points 

        scoreDisplay.addScore(50);
        //scoreText.SetText("Score: " + score);
    }
}
