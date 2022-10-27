using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnLocation : MonoBehaviour
{
    private int mapIndex;
    public float[,] coordinates;
    public ObjectSpawnLocation objectSpawnLocationInstance;
    void Start()
    {

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
    //2d array to account for maps that have more than one area
    public float[,] getCoordinates()
    {
        switch (getMapIndex())
        {
            //first row in array can't be accessed, for maps that returns only one boundary
            //
            //minX, maxX, minY, maxY, yPos(height)
            case 1:
                return coordinates = new float[,] { { 0f, 0f, 0f, 0f, 0f }, { -24f, 24f, -24f, 24f, 0.6f } };
            case 2:
                return coordinates = new float[,] { { 0f, 0f, 0f, 0f, 0f }, { -16f, 16f, -16f, 16f, 1.2f } };
            case 3:
                return coordinates = new float[,] { { 0f, 0f, 0f, 0f, 0f }, { -25f, 25f, -25f, 25f, 3.8f } };
            case 4:
                return coordinates = new float[,] { { 0f, 0f, 0f, 0f, 0f }, { -25f, 25f, -25f, 25f, 0.6f } };
            case 5:
                return coordinates = new float[,] { { 0f, 0f, 0f, 0f, 0f }, { -15f, 25f, -15f, 25f, 1.3f } };
            default:
                return coordinates = new float[,] { { 0f, 0f, 0f, 0f, 0f }, { -15f, 25f, -15f, 25f, 3.8f } };
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