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
       // StartCoroutine(pause1Sec());
       // baseSpeed = playerController.getMoveSpeed();
    }

    IEnumerator pause1Sec()
    {
        yield return new WaitForSeconds(1);
    }

    // Update is called once per frame
    void Update()
    {
       //this.currentSpeed = playerController.getMoveSpeed();
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
