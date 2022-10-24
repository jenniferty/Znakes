using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    public GameObject cannonBall;
    private float radius;
    private float power;
    private float upForce;
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
        if(collision.gameObject.CompareTag("wall"))
        {
            GrowTree();
            Destroy(gameObject);
        }else if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController player = collision.gameObject.GetComponent<PlayerHealthController>();
            player.TakeDamage(3);
            Destroy(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    public void GrowTree()
    {
        Instantiate(treePrefab, transform.position, Quaternion.Euler(0,0,0));
    }
}