using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform[] foodLocations;
    public GameObject foodGameObj;
    private Transform previousLocation;

    void Start()
    {
        foodLocations = GetComponentsInChildren<Transform>();
        Spawn();
    }

    // // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        //Random generate a number between the total num of locations
        //Also need to make sure the food does spawn where the player is
        int chosenLocation = Random.Range(1, foodLocations.Length);

        if (foodLocations[chosenLocation] == previousLocation)
        {
            chosenLocation++;
            if (chosenLocation >= foodLocations.Length)
            {
                chosenLocation = 1;
            }
        }


        Instantiate(foodGameObj, foodLocations[chosenLocation].position, Quaternion.identity);
        previousLocation = foodLocations[chosenLocation];
    }
}