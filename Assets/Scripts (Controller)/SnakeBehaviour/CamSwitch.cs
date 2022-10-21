using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject firstPersonCam;
    public GameObject thirdPersonCam;


    // Update is called once per frame
    void Update()
    {
        //camera switch
        if (Input.GetKeyDown("1"))
        {
            firstPersonCam.SetActive(true);
            thirdPersonCam.SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {
            firstPersonCam.SetActive(false);
            thirdPersonCam.SetActive(true);
        }
    }
}
