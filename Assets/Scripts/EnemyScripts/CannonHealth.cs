using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonHealth : MonoBehaviour
{
    // Settings
    private int hits;
    private int maxHits = 3;
    public GameObject enemy;
    public SuspiciousCannonBehaviour behaviour;
    public ScoreSystemDisplay scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        //grab component of parent object
        behaviour = enemy.GetComponent<SuspiciousCannonBehaviour>();
        scoreDisplay = GameObject.Find("Score").GetComponent<ScoreSystemDisplay>();
        setHits(0);
    }

    // Update is called once per frame
    void Update()
    {
        //check if cannon can be destroyed
        if (getHits() == getMaxHits())
        {
            behaviour.setDestroyed();
            Destroy(gameObject);
            scoreDisplay.addScore(70);
        }
    }
    public void TakeHit()
    {
        setHits(getHits() + 1);
    }
    public int getHits()
    {
        return this.hits;
    }
    public void setHits(int hits)
    {
        this.hits = hits;
    }
    public int getMaxHits()
    {
        return maxHits;
    }
}