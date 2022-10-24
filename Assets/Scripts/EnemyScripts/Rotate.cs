using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float maxUp = 22.5f;
    private float mid = 0f;
    private float maxDown = -22.50f;
    void Start()
    {
        InvokeRepeating("RotateUp", 0f, 12f);
        InvokeRepeating("RotateMid", 3f, 12f);
        InvokeRepeating("RotateDown", 6f, 12f);
        InvokeRepeating("RotateMid", 9f, 12f);
    }
    void Update()
    {
        
    }

    public void RotateUp()
    {
        transform.eulerAngles = new Vector3(getMaxUp(),transform.eulerAngles.y,transform.eulerAngles.z);
    }
    public void RotateMid()
    {
        transform.eulerAngles = new Vector3(getMid(),transform.eulerAngles.y,transform.eulerAngles.z);
    }
    public void RotateDown()
    {
        transform.eulerAngles = new Vector3(getMaxDown(),transform.eulerAngles.y,transform.eulerAngles.z);
    }
    public float getMaxUp()
    {
        return this.maxUp;
    }
    public float getMid()
    {
        return this.mid;
    }
    public float getMaxDown()
    {
        return this.maxDown;
    }
}
