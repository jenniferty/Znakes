using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public CharacterController controller;

    // Settings
    public int health = 100;
    public int maxHealth = 100;
    public float speed = 5;
    public float rotationSpeed = 180;

    Camera attachedCam;
    public HealthBar healthBar;
    public LoseScreen loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        attachedCam = GameObject.Find("Third Person Camera").GetComponent<Camera>();
        healthBar.SetHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // For constant forward movement
        controller.Move(transform.forward * speed * Time.deltaTime);

        // Rotation with arrow keys
        float direction = Input.GetAxis("Horizontal"); 
        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);

        // Health and Death
        healthBar.SetHealth(health);
        CheckDeath();
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
}
