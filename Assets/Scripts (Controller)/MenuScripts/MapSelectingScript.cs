using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectingScript : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    public void Story ()
    {
        audioManager.playGameStopMenuTheme();
        SceneChanger.LoadScene("Story");
    }

    public void Map1 ()
    {
        audioManager.playGameStopMenuTheme();
        SceneChanger.LoadScene("Map1");
    }

    public void Map2 ()
    {
        audioManager.playGameStopMenuTheme();
        SceneChanger.LoadScene("Map2");
    }

    public void Map3 ()
    {
        audioManager.playGameStopMenuTheme();
        SceneChanger.LoadScene("Map3");
    }

    public void Map4 ()
    {
        audioManager.playGameStopMenuTheme();
        SceneChanger.LoadScene("Map4");
    }

    public void Map5 ()
    {
        audioManager.playGameStopMenuTheme();
        SceneChanger.LoadScene("Map5");
    }

    

}
