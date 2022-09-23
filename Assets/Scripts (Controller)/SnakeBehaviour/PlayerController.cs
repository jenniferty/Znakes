using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

    


    // Settings
    public int health = 100;
    public int maxHealth = 100;
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float bodySpeed = 5;
    public int Gap = 20;


    Camera attachedCam;
    public HealthBar healthBar;
    public LoseScreen loseScreen;

    //for the snake Tail/Growth
    public GameObject snakeBody;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHist = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        attachedCam = GameObject.Find("Third Person Camera").GetComponent<Camera>();
        healthBar.SetHealth(maxHealth);
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

        // Health and Death
        healthBar.SetHealth(health);
        CheckDeath();
    }

  

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            PauseGame.Pause();
            loseScreen.ShowDeathScreen();
        }
    }
    public void GrowSnake()
    {
        GameObject body = Instantiate(snakeBody);
        bodyParts.Add(body);
    }
}
