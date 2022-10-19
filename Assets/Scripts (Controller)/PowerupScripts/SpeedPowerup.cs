using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public GameObject speedPowerup;
    public PlayerSpeedController speedController;
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float steerSpeedMultiplier = 1.3f;
    [SerializeField] private float abilityTimer = 10f;

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
        speedController.backToPreviousSpeed();
        Debug.Log("Speed Powerup used up");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setSpeedController(other);
            speedController.saveCurrentSpeed();
            MultiplySpeed(getSpeedMultiplier());
            StartCoroutine(ActiveTimer());
            Destroy(gameObject);
        }
    }

    public void MultiplySpeed(float speedMultiplier)
    {
        {
            speedController.setSpeed(speedController.getPreviousSpeed() * getSpeedMultiplier());
            speedController.setSteerSpeed(speedController.getPreviousSteerSpeed() * getSteerSpeedMultiplier());
        }
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
    public void setSpeedController(Collider other)
    {
        speedController = other.GetComponent<PlayerSpeedController>();
    }
}
