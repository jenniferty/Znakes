//adapted from https://learn.unity.com/tutorial/using-c-to-launch-projectiles#5fd7ab3bedbc2a7fb11f4e41
//modified cannon prefab from same link
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCannonBall : MonoBehaviour
{
    public GameObject cannonBall;
    public float launchVelocity = 700f;
    void Start()
    {
        InvokeRepeating("Launch", 1f, 3f);
    }
    void Update()
    {

    }
    public void Launch()
    {
        FindObjectOfType<AudioManager>().Play("SuspiciousCannon");
        GameObject ball = Instantiate(cannonBall, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(0, launchVelocity, 0);
    }
}