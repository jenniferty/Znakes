using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystemDisplay : MonoBehaviour
{
    private int score;

    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        setScore(0);
    }

   

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + getScore()); 
    }

    public int getScore()
    {
        return this.score;
    }
    public void setScore(int score)
    {
        this.score = score;
    }
    public void addScore(int score)
    {
        setScore(getScore() + score);
    }
}
