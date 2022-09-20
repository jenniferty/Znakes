using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public CharacterController controller;

    // Settings
    public float speed = 5;
    public float rotationSpeed = 180;

    // Start is called before the first frame update
    void Start()
    {

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

    //todo
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            Destroy(controller.gameObject);
        }

        /*if (controller.collisionFlags == CollisionFlags.Bomb)
        {

        }*/
    }
}
