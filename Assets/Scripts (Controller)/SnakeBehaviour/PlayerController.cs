using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    public CharacterController controller;

    public float SPEED = 5f;
    float HORIZONTAL = 0f;
    Vector3 DIRECTION = new Vector3(0, 0, 1);
    //float VERTICAL = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //VERTICAL = 1f; // init value being used in direction vector
    }

    // Update is called once per frame
    void Update()
    {
        // Tests for new input before taking
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            myInput();
        }

        if (HORIZONTAL > 1)
        {
            // transform.rotation = Quaternion.Euler(transform.right * speed);
            DIRECTION = new Vector3(1, 0, 0);
            transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * SPEED, Space.Self);
        }
        else if (HORIZONTAL < 1)
        {
            //transform.rotation = Quaternion.Euler(-transform.right);
            DIRECTION = new Vector3(-1, 0, 0);
            transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * SPEED, Space.Self);
        }
        //Vector3 direction = new Vector3(HORIZONTAL, 0f, VERTICAL).normalized;
        
        // Turns character to look in direction of movement. Slerp smoothens turn
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);

        // Force for Constant Movement
        controller.Move(DIRECTION * SPEED * Time.deltaTime);
    }

    // Used to get and store input values to use in constant movement.
    void myInput()
    {
        float tempHorizontal = Input.GetAxisRaw("Horizontal");
        HORIZONTAL = tempHorizontal;

    }
    */

    public CharacterController controller;
    public float _speed = 10;
    public float _rotationSpeed = .1f;

    private Vector3 rotation;

    public void Update()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);

        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = this.transform.TransformDirection(move);
        controller.Move(move * _speed);
        this.transform.Rotate(this.rotation);
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            Destroy(controller.gameObject);
        }
    }
}
