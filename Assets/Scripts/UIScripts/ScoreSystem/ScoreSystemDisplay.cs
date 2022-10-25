using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystemDisplay : MonoBehaviour
{
    public static int score;

    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        score = 0;
    }

   

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + score); 
    }
}
