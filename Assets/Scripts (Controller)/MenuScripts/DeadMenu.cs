using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public void RetryLevel()
    {
<<<<<<< HEAD
        
        
=======
        //Retrylevel: load last scene
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("Map1");
>>>>>>> parent of 3a4cc5be (Got rid of testcode)
        FindObjectOfType<AudioManager>().Stop("MenuTheme");
        FindObjectOfType<AudioManager>().Play("GameTheme");
    }




    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
