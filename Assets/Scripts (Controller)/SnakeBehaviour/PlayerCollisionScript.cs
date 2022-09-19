using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    public FoodSpawnerScript foodSpawner;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision ");

        if (collider.CompareTag("Food"))
        {
            foodSpawner.Spawn();
            Destroy(collider.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
