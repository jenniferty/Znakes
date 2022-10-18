using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float steerSpeed = 180;
    [SerializeField] private float bodySpeed = 5;
    [SerializeField] private int gap = 10;
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
        transform.position += transform.forward * moveSpeed * Time.deltaTime;


        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);


        if (!PauseGame.isPaused)
        {
            //new growth function code
            positionHist.Insert(0, transform.position);

            //set to 1 so the head does not collide with the snake in the beginning
            int index = 2;
            foreach (var body in bodyParts)
            {
                Vector3 point = positionHist[Mathf.Min(index * gap, positionHist.Count - 1)];
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

    public float getMoveSpeed()
    {
        return this.moveSpeed;
    }
    public float getSteerSpeed()
    {
        return this.steerSpeed;
    }
    public float getBodySpeed()
    {
        return this.bodySpeed;
    }
    public int getGap()
    {
        return this.gap;
    }
    public void setMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
    public void setSteerSpeed(float steerSpeed)
    {
        this.steerSpeed = steerSpeed;
    }
    public void setBodySpeed(float bodySpeed)
    {
        this.bodySpeed = bodySpeed;
    }
    public void setGap(int gap)
    {
        this.gap = gap;
    }

    public void setSpeed(float speed)
    {
        setMoveSpeed(speed);
        setBodySpeed(speed);
    }
}
