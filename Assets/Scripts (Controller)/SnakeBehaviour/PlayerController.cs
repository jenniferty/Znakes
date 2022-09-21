using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    public CharacterController controller;

    // Settings
    public float speed = 5;
    public float rotationSpeed = 180;
    Camera attachedCam;


    // Start is called before the first frame update
    void Start()
    {
        attachedCam = GameObject.Find("Third Person Camera").GetComponent<Camera>();


    }

    // Update is called once per frame
    void Update()
    {
        // For constant forward movement
        controller.Move(transform.forward* speed *Time.deltaTime);

        // Rotation with arrow keys
        float direction = Input.GetAxis("Horizontal"); 
        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            attachedCam.transform.parent = null;
            Destroy(controller.gameObject);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Scene index: 0 = main menu, 1 = game, 2 = option menu that will pop up when sanke dies.
    }

    
}
