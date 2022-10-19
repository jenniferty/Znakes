using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedController : MonoBehaviour
{
    public PlayerController playerController;

    private Stack<float> speedStack = new Stack<float>();
    private Stack<float> steerSpeedStack = new Stack<float>();

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.currentSpeed = playerController.getMoveSpeed();
    }

    public void backToPreviousSpeed()
    {
        setSpeed(speedStack.Pop());
        setSteerSpeed(steerSpeedStack.Pop());
    }

    public void saveCurrentSpeed()
    {
        speedStack.Push(playerController.getMoveSpeed());
        steerSpeedStack.Push(playerController.getSteerSpeed());
    }

    public void setSpeed(float speed)
    {
        playerController.setMoveSpeed(speed);
        playerController.setBodySpeed(speed);
    }
    public void setSteerSpeed(float steerSpeed)
    {
        playerController.setSteerSpeed(steerSpeed);
    }
    public float getPreviousSpeed()
    {
        return speedStack.Peek();
    }
    public float getPreviousSteerSpeed()
    {
        return steerSpeedStack.Peek();
    }
}
