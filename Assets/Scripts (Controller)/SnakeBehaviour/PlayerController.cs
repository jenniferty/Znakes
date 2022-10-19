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
    private int bodyCount = 0;
    Camera attachedCam;

    //for the snake Tail/Growth
    public GameObject snakeBody;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHist = new List<Vector3>();

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
    void Update()
    {
        //new movementcode
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;


        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);


        if (!PauseGame.isPaused)
        {
            //new growth function code
            positionHist.Insert(0, transform.position);

            //set to 1 so the head does not collide with the snake in the beginning
            int index = 3;
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
        setBodyCount(getBodyCount() + 1);
    }
    public int getBodyCount()
    {
        return bodyCount;
    }
    public void setBodyCount(int bodyCount)
    {
        this.bodyCount = bodyCount;
    }
}
