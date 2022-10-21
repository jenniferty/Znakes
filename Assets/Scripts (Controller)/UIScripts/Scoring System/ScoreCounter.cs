using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//script which holds score
public class ScoreCounter : MonoBehaviour
{
    public static int score;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
   void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        score = 0;
    }
   

    private void OnTriggerEnter(Collider other)
    {
        score += 50;
        scoreText.SetText("Score: " + score);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       // score += 1;
        scoreText.SetText("Score: " + score); 
    }
   
}
