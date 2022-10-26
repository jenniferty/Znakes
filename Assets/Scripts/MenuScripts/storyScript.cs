using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back()
    {
        SceneChanger.LoadScene("MainMenu");
    }
}
