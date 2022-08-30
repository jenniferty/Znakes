using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // +++++++++++++++++++++++++++++++++++++++++++++

    //LAWRENCE'S Movement

    // +++++++++++++++++++++++++++++++++++++++++++++

    /*
    // public GameObject playerobject;
    //public float speed;
    //public float turnningspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        playerobject.transform.position += playerobject.transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        { 
            playerobject.transform.Rotate(-Vector3.up * turnningspeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerobject.transform.Rotate(Vector3.up * turnningspeed * Time.deltaTime);
        }
    }
    */



    // +++++++++++++++++++++++++++++++++++++++++++++

    // ANTHONY'S Movement

    // +++++++++++++++++++++++++++++++++++++++++++++

    public CharacterController controller;

    public float SPEED = 5f;
    float HORIZONTAL = 0f;
    float VERTICAL = 0f;


    // Start is called before the first frame update
    void Start()
    {
        VERTICAL = 1f; // init value being used in direction vector
    }

    // Update is called once per frame
    void Update()
    {
        // Tests for new input before taking
        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
            myInput();
        }

        Vector3 direction = new Vector3(HORIZONTAL, 0f, VERTICAL).normalized;

        // Turns character to look in direction of movement.
        // Slerp smoothens turn
        if (direction.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15f);
        }

        // Force for Constant Movement
        controller.Move(direction * SPEED * Time.deltaTime);
    }

    // Used to get and store input values to use in constant movement.
    void myInput()
    {
        float tempHorizontal = Input.GetAxisRaw("Horizontal");
        float tempVertical = Input.GetAxisRaw("Vertical");

        // Only allow change if input is not opposite on axis (no backwards)
        if (tempHorizontal == (HORIZONTAL + 1) || tempHorizontal == HORIZONTAL - 1)
        {
            HORIZONTAL = tempHorizontal;
        }

        if (tempVertical == (VERTICAL + 1) || tempVertical == VERTICAL - 1)
        {
            VERTICAL = tempVertical;
        }
    }


    // +++++++++++++++++++++++++++++++++++++++++++++
    // LAWRENCE'S Collision

    // +++++++++++++++++++++++++++++++++++++++++++++

   /* OLD VERSION REQUIRED RIGIDBODY
    * 
    * private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall_obstacle")
        {
            Destroy(playerobject);
        }
    }
   */

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (controller.collisionFlags == CollisionFlags.Sides)
        {
            Destroy(controller.gameObject);
        }
    }
}
