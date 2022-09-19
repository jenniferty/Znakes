using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public CharacterController controller;
    public int gapBetween = 10;

    //Snake Body Object
    public GameObject snakeBody;
    private List<GameObject> snakeBodyParts = new List<GameObject>();

    //for the body parts following the snake
    private List<Vector3> PositionHistory = new List<Vector3>();
   
    // Settings
    public float speed = 5;
    public float rotationSpeed = 180;

    // Start is called before the first frame update
    void Start()
    {
        snakeGrowth();
        
    }

    // Update is called once per frame
    void Update()
    {
        // For constant forward movement
        controller.Move(transform.forward* speed *Time.deltaTime);

        // Rotation with arrow keys
        float direction = Input.GetAxis("Horizontal"); 
        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);

        ////body position history
        //PositionHistory.Insert(0, transform.position);

        //making the body parts move
        int index = 0;
        foreach(var body in snakeBodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(index * gapBetween, PositionHistory.Count - 1)];
            body.transform.position = point;
            index++;
        }

    }

    //for the snake growth
    public void snakeGrowth()
    {
        //GameObject snakeBody = Instantiate(snakeBody);
        //snakeBodyParts.Add(snakeBody);
        
    }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (controller.collisionFlags == CollisionFlags.Sides)
    //    {
    //        Destroy(controller.gameObject);
    //    }
    //}
}
