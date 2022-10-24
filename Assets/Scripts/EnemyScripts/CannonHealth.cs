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
    public PlayerController playerController;
    public SuspiciousCannonBehaviour behaviour;

    // Start is called before the first frame update
    void Start()
    {
        behaviour = enemy.GetComponent<SuspiciousCannonBehaviour>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        setHits(0);
        Debug.Log("max hits is"+getMaxHits());
    }

    // Update is called once per frame
    void Update()
    {
        if(getHits() == getMaxHits())
        {
            behaviour.setDestroyed();
            Destroy(gameObject);
        }
    }
    public void TakeHit()
    {
        setHits(getHits() + 1);
        Debug.Log("hit count"+ getHits());
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