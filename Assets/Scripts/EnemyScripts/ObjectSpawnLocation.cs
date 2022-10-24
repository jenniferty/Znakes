using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnLocation : MonoBehaviour
{
    private int mapIndex;
    public float[,] coordinates;
    public ObjectSpawnLocation objectSpawnLocationInstance;
    void Start(){
        
    }

    void Awake()
    {
        // Remove duplicate instances
        if (objectSpawnLocationInstance == null)
        {
            objectSpawnLocationInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Keep same manager instance when scenes change
        DontDestroyOnLoad(gameObject);
    }

    public float[,] getCoordinates()
    {
        switch(getMapIndex())
        {
            //first row in array can't be accessed, for maps that returns only one boundary
            //
            //minX, maxX, minY, maxY, yPos(height)
            case 1:
            Debug.Log("1");
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-15f, 15f, -15f, 15f, 3.8f}};
            case 2:
            Debug.Log("2");
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-10f, 10f, -10f, 10f, 3.8f}};
            case 3:
            Debug.Log("3");
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
            case 4:
            Debug.Log("4");
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-17f, 17f, -17f, 17f, 3.8f}};
            case 5:
            Debug.Log("5");
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
            default:
            Debug.Log("default");
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-15f, 25f, -15f, 25f, 3.8f}};
        }
    }
    public int getMapIndex()
    {
        return this.mapIndex;
    }
    public void setMapIndex(int mapIndex)
    {
        this.mapIndex = mapIndex;
    }
}