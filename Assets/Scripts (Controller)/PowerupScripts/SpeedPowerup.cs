using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public GameObject speedPowerup;
    public PlayerSpeedController speedController;
    public PlayerController playerController;
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float steerSpeedMultiplier = 1.3f;
    [SerializeField] private float abilityTimer = 20f;
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
        backToPreviousSpeed();
        Debug.Log("Speed Powerup used up");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setPlayerController(other);
            saveCurrentSpeed();
            MultiplySpeed(getSpeedMultiplier());
            StartCoroutine(ActiveTimer());
            Destroy(gameObject);
        }
    }

    public void MultiplySpeed(float speedMultiplier)
    {
        {
            playerController.setSpeed(speedStack.Peek() * getSpeedMultiplier());
            playerController.setSteerSpeed(steerSpeedStack.Peek() * getSteerSpeedMultiplier());
        }
        Destroy(gameObject);    // Remove PickupspeedStack.Pop()
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
