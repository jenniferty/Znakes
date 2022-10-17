using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    public GameObject speedPowerup;
    public PlayerSpeedController speedController;
    //[SerializeField] private bool isActive = false;
    [SerializeField] private float speedMultiplier = 1.7f;
    [SerializeField] private float abilityTimer = 20f;
    //[SerializeField] private float additionalTime = 10f;

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
        Debug.Log("Starting timer");
        yield return new WaitForSeconds(abilityTimer);
        backToBaseSpeed();
        Debug.Log("Speed Powerup used up");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            setSpeedController(other);
            //MultiplySpeed(getSpeedMultiplier(), other);
            PlayerSpeedController playerObject = other.GetComponent<PlayerController>().GetComponent<PlayerSpeedController>();
            if (playerObject == null)
            {
                Debug.Log("FindWithTag returned null for Player tag");
            }
            StartCoroutine(ActiveTimer());
        }
    }

    public void MultiplySpeed(float speedMultiplier, Collider other)
    {
        {
            other.GetComponent<PlayerSpeedController>().setSpeed(speedController.getCurrentSpeed() * getSpeedMultiplier());
        }
        Destroy(gameObject);    // Remove Pickup
    }

    public void backToBaseSpeed()
    {
        speedController.setSpeed(speedController.getBaseSpeed());
    }
    
    public float getSpeedMultiplier()
    {
        return this.speedMultiplier;
    }
    public void setSpeedMultiplier(int speedMultiplier)
    {
        this.speedMultiplier = speedMultiplier;
    }
    public void setSpeedController(Collider other)
    {
        this.speedController = other.GetComponent<PlayerController>().GetComponent<PlayerSpeedController>();
    }
}
