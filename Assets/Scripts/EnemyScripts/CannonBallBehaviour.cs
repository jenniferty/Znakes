using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject treePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        //grows tree when hits ground
        if (collision.gameObject.CompareTag("wall"))
        {
            GrowTree();
            Destroy(gameObject);
        }
        //damages player when hits player
        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController player = collision.gameObject.GetComponent<PlayerHealthController>();
            player.TakeDamage(3);
            Destroy(gameObject);
        }
        //is destroyed when it hits anything else
        else
        {
            Destroy(gameObject);
        }
    }

    //instantiates a tree prefab right side up
    public void GrowTree()
    {
        Instantiate(treePrefab, transform.position, Quaternion.Euler(0, 0, 0));
    }
}