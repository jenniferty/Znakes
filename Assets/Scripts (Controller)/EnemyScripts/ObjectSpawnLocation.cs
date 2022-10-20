using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnLocation : MonoBehaviour
{
    private int mapIndex;
    public float[,] coordinates;
    void Start(){
        
    }

    public float[,] getCoordinates()
    {
        switch(getMapIndex())
        {
            //first row in array can't be accessed, for maps that returns only one boundary
            //
            //minX, maxX, minY, maxY, yPos(height)
            case 0:
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
            case 1:
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
            case 2:
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
            case 3:
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
            case 4:
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
            default:
            return coordinates = new float[,]{{0f, 0f, 0f, 0f, 0f},{-25f, 25f, -25f, 25f, 3.8f}};
        }
    }
    public float getMapIndex()
    {
        return this.mapIndex;
    }
    public void setMapIndex(int mapIndex)
    {
        this.mapIndex = mapIndex;
    }
}