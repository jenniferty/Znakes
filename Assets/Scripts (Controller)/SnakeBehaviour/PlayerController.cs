using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    // Settings
    public float speed = 5;
    public float rotationSpeed = 180;
    public int gap = 10;

    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 2; i++)
        {
            GrowSnake();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // For constant forward movement
        transform.position += transform.forward * speed * Time.deltaTime;

        // Rotation with arrow keys
        float direction = Input.GetAxis("Horizontal");
        Debug.Log(direction);
        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);

        // Storing Position
        PositionsHistory.Insert(0, transform.position);

        // Moving bodyparts
        int index = 0;
        foreach (var body in BodyParts)
        {
            // point is the latest position in history 
            Vector3 point = PositionsHistory[Mathf.Min(index * gap, PositionsHistory.Count-1)];

            // Follow head
            Vector3 followDirection = point - body.transform.position;
            body.transform.position += followDirection * speed * Time.deltaTime;

            // Rotate body parts as they follow
            body.transform.LookAt(point);

            index++;
        }
    }

    private void GrowSnake()
    {
        GameObject Cube_body = Instantiate(BodyPrefab);
        BodyParts.Add(Cube_body);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall")
        {
            Debug.Log("hit Wall");
        }
    }
}
