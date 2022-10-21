using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float bodySpeed = 5;
    public int Gap = 10;
    Camera attachedCam;

    //for the snake Tail/Growth
    public GameObject snakeBody;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHist = new List<Vector3>();

    public bool isSprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        attachedCam = GameObject.Find("Third Person Camera").GetComponent<Camera>();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //sprint functions
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = 10;
            bodySpeed = 10;
            Gap = 5;
        }
        else
        {
            MoveSpeed = 5;
            bodySpeed = 5;
            Gap = 10;
        }

        //new movementcode
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        if (!PauseGame.isPaused)
        {
            //new growth function code
            positionHist.Insert(0, transform.position);

            //set to 1 so the head does not collide with the snake in the beginning
            int index = 1;
            foreach (var body in bodyParts)
            {
                Vector3 point = positionHist[Mathf.Min(index * Gap, positionHist.Count - 1)];
                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * bodySpeed * Time.deltaTime;
                body.transform.LookAt(point);
                index++;
            }
        }
        
    }
    public void GrowSnake()
    {
        GameObject body = Instantiate(snakeBody);
        bodyParts.Add(body);
    }
}
