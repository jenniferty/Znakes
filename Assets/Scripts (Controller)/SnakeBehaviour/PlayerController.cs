using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Character Controller will delete later depending on movement
   // public CharacterController controller;

    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float bodySpeed = 5;
    public int Gap = 20;


    //new code for growth function
    public GameObject snakeBody;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHist = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // For constant forward movement
        //controller.Move(transform.forward * speed * Time.deltaTime);

        //new movement replacing character controller
        //moving forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;


        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);


        // Rotation with arrow keys
        //float direction = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);

        //new growth function code
        positionHist.Insert(0, transform.position);

        int index = 0;
        foreach (var body in bodyParts)
        {
            Vector3 point = positionHist[Mathf.Min(index * Gap, positionHist.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * bodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

    }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (controller.collisionFlags == CollisionFlags.Sides)
    //   {
    //      Destroy(controller.gameObject);
    //    }
    //}

    //private void OnCollisionEnter(Collision hit)
    //{
    //    if (hit.transform.tag == "wall")
    //    {
    //        Destroy(snakeBody);
    //        Debug.Log("HIt Wall");
    //    }
    //}

    public void GrowSnake()
    {
        GameObject body = Instantiate(snakeBody);
        bodyParts.Add(body);
    }
}
