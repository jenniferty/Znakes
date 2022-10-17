using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    public PlayerController playerController;
    private float baseSpeed;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        baseSpeed = playerController.getMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        this.currentSpeed = playerController.getMoveSpeed();
    }

    public void setSpeed(float speed)
    {
        playerController.setMoveSpeed(speed);
        playerController.setBodySpeed(speed);
    }
    public float getBaseSpeed()
    {
        return this.baseSpeed;
    }
    public float getCurrentSpeed()
    {
        return this.currentSpeed;
    }
}
