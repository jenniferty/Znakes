using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float steerSpeed = 180;
    [SerializeField] private float bodySpeed = 5;
    [SerializeField] private int gap = 15;
    private int bodyCount = 0;
    private bool speedPowerupIsActive = false;
    private bool isSprinting = false;
    private bool hasStamina = true;
    Camera attachedCam;
    StaminaBar staminaBar;

    //for the snake Tail/Growth
    public GameObject snakeBody;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHist = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        attachedCam = GameObject.Find("Third Person Camera").GetComponent<Camera>();
        staminaBar = GameObject.Find("StaminaBar").GetComponent<StaminaBar>();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        //Debug.Log(getBodyCount());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //sprint functions
        if (!speedPowerupIsActive)
        {
            ShiftSprint();
        }
        
        staminaBar.UpdateStamina();

        //new movementcode
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * steerSpeed * Time.deltaTime);

        if (!PauseGame.isPaused)
        {
            //new growth function code
            positionHist.Insert(0, transform.position);

            //set to 1 so the head does not collide with the snake in the beginning
            int index = 1;
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
        setBodyCount(getBodyCount() + 1);
    }

    public void ShiftSprint()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        if (isSprinting && hasStamina)
        {
            setMoveSpeed(10f);
            setBodySpeed(10f);
            setGap(5);
        }
        else
        {
            setMoveSpeed(5f);
            setBodySpeed(5f);
            setGap(10);
        }
    }

    public int getBodyCount()
    {
        return this.bodyCount;
    }
    public void setBodyCount(int bodyCount)
    {
        this.bodyCount = bodyCount;
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
    public bool getIsSprinting()
    {
        return this.isSprinting;
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
    public void setSpeedPowerupIsActive(bool isActive)
    {
        this.speedPowerupIsActive = isActive;
    }
    public void SetHasStamina(bool hasStamina)
    {
        this.hasStamina = hasStamina;
    }

    /*
     * This is used by the SpeedPowerup script
     */
    public void setSpeed(float speed)
    {
        setMoveSpeed(speed);
        setBodySpeed(speed);
    }
}
