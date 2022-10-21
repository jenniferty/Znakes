using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public void RetryLevel()
    {
        
        
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
        FindObjectOfType<AudioManager>().Play("GameTheme");
    }




    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
