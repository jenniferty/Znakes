using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject thirdPersonCamera;
    public GameObject firstPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        thirdPerson();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("3"))
        {
            thirdPerson();
        }
        if (Input.GetKey("1"))
        {
            firstPerson();
        }

    }


    public void thirdPerson()
    {
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
    }

    public void firstPerson()
    {
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
    }
}
