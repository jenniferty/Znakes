// using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class IgnoreDamage : MonoBehaviour
{

    public PlayerHealthController playerHealthController;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthController =
            GameObject
<<<<<<< HEAD
                .Find("Player")
=======
                .Find("PlayerHealthController")
>>>>>>> b74715a3d6773dde5058d77d79ed64e498d44f70
                .GetComponent<PlayerHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            playerHealthController.ignoreDamage = true;
        }
        else
        {
            playerHealthController.ignoreDamage = false;
        }
    }
}
