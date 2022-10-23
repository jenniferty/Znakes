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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("3"))
        {
            firstPersonCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
        }
        if (Input.GetKey("1"))
        {
            firstPersonCamera.SetActive(true);
            thirdPersonCamera.SetActive(false);
        }

    }
}
