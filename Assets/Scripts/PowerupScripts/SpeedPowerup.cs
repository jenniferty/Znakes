using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public GameObject speedPowerup;
    public PlayerController playerController;
    private float speedMultiplier = 1.24f;
    private float steerSpeedMultiplier = 1.13f;
    private float abilityTimer = 10f;
    private Stack<float> speedStack = new Stack<float>();
    private Stack<float> steerSpeedStack = new Stack<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Remove pickup after 10 seconds
        if (speedPowerup == enabled)
        {
            Invoke("TimeOut", 10);
        }
    }

    void TimeOut()
    {
        Destroy(gameObject);
    }

    IEnumerator ActiveTimer()
    {
        Debug.Log("Starting speed timer");
        yield return new WaitForSeconds(abilityTimer);
        Debug.Log("timer returned");
        backToPreviousSpeed();
        backToPreviousSpeed();
        playerController.setSpeedPowerupIsActive(false);
        Destroy(gameObject);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setPlayerController(other);
            playerController.setSpeedPowerupIsActive(true);
            saveCurrentSpeed();
            MultiplySpeed();    //Somehow this is being called twice. Currently working around this bug by returning to prev x2
            StartCoroutine(ActiveTimer());
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
    }

    public void MultiplySpeed()
    {
     
        playerController.setSpeed(speedStack.Peek() * getSpeedMultiplier());
        playerController.setSteerSpeed(steerSpeedStack.Peek() * getSteerSpeedMultiplier());
     
    }

    public void backToPreviousSpeed()
    {
        playerController.setSpeed(speedStack.Pop());
        playerController.setSteerSpeed(steerSpeedStack.Pop());
    }

    public void saveCurrentSpeed()
    {
        speedStack.Push(playerController.getMoveSpeed());
        steerSpeedStack.Push(playerController.getSteerSpeed());
    }
    
    public float getSpeedMultiplier()
    {
        return this.speedMultiplier;
    }
    public float getSteerSpeedMultiplier()
    {
        return this.steerSpeedMultiplier;
    }
    public void setSpeedMultiplier(int speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }
    public void setPlayerController(Collider other)
    {
        this.playerController = other.GetComponent<PlayerController>();
    }
}
