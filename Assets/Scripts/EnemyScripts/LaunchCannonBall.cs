//adapted from https://learn.unity.com/tutorial/using-c-to-launch-projectiles#5fd7ab3bedbc2a7fb11f4e41
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannonBall : MonoBehaviour
{
    public GameObject cannonBall;
    public float launchVelocity = 700f;
    void Start()
    {
        InvokeRepeating("Launch", 0f, 3f);
    }
    void Update()
    {
        
    }
    public void Launch()
    {
        GameObject ball = Instantiate(cannonBall, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(0, launchVelocity, 0);
    }
}