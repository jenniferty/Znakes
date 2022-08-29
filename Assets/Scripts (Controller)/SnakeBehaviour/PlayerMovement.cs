using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
}