using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PauseGame : MonoBehaviour
{
    public static bool isPaused = false;

    //public PlayerController playerController;

    public GameObject PauseMenu;



    /*Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        //Cursor.lockState = CursorLockMode.Confined;
       

    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("clicked");
     

    }

    public void MenuButton()
    {
        SceneChanger.LoadScene("MainMenu");
        Time.timeScale = 1f;
        Debug.Log("Go to menus");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
