using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public CharacterController controller;

    // Settings
    public int health = 100;
    public int maxHealth = 100;
    //public float speed = 5;
    //public float rotationSpeed = 180;
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float bodySpeed = 5;
    public int Gap = 20;

    Camera attachedCam;
    public HealthBar healthBar;
    public LoseScreen loseScreen;

    //code for growth function
    public GameObject snakeBody;
    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionHist = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        attachedCam = GameObject.Find("Third Person Camera").GetComponent<Camera>();
        healthBar.SetHealth(maxHealth);

        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {
        // For constant forward movement
        //controller.Move(transform.forward * speed * Time.deltaTime);

        // Rotation with arrow keys
        // float direction = Input.GetAxis("Horizontal"); 
        // transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);

        //new controle movement
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Health and Death
        healthBar.SetHealth(health);
        CheckDeath();

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

    //todo
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Sides"))
        {
            attachedCam.transform.parent = null;
            //attachedCam.transform.parent = null;
            TakeDamage(100);
        }
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
