using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerobject;
    public float speed;
    public float turnningspeed;
    void Start()
    {
        
    }
    /*
    // Update is called once per frame
    void Update()
    {
        playerobject.transform.position += playerobject.transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        { 
            playerobject.transform.Rotate(-Vector3.up * turnningspeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerobject.transform.Rotate(Vector3.up * turnningspeed * Time.deltaTime);
        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wall_obstacle")
        {
            Destroy(playerobject);
        }
    }
}
