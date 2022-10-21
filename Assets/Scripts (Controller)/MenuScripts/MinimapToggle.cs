using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapToggle : MonoBehaviour
{
    public static bool isActive = true;
    public GameObject minimap;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isActive)
            {
                MapToggleOn();
            }
            else
            {
                MapToggleOff();
            }
        }
    }

    public void MapToggleOn()
    {
        minimap.SetActive(true);
        isActive = true;
    }

    public void MapToggleOff()
    {
        minimap.SetActive(false);
        isActive = false;
    }
}