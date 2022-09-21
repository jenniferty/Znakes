using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public CharacterController controller;
    public int health = 100;
    Camera attachedCam;

    // Settings
    public float speed = 5;
    public float rotationSpeed = 180;

    // Start is called before the first frame update
    void Start()
    {
        attachedCam = GameObject.Find("Third Person Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Destroys player object when health reaches zero. update to end game only
        if (health <= 0)
        {
            attachedCam.transform.parent = null;
            Destroy(controller.gameObject);
        }
        // For constant forward movement
        controller.Move(transform.forward* speed *Time.deltaTime);

        // Rotation with arrow keys
        float direction = Input.GetAxis("Horizontal"); 
        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);

    }

    //todo
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Sides"))
        {
            attachedCam.transform.parent = null;
            Destroy(controller.gameObject);
        }
    }
}
