using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectingScript : MonoBehaviour
{
    private AudioManager audioManager;
    public ObjectSpawnLocation location;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        location = FindObjectOfType<ObjectSpawnLocation>();
    }
    public void Map1 ()
    {
        audioManager.playGameStopMenuTheme();
        location.setMapIndex(1);
        SceneChanger.LoadScene("Map1");
    }

    public void Map2 ()
    {
        audioManager.playGameStopMenuTheme();
        location.setMapIndex(2);
        SceneChanger.LoadScene("Map2");
    }

    public void Map3 ()
    {
        audioManager.playGameStopMenuTheme();
        location.setMapIndex(3);
        SceneChanger.LoadScene("Map3");
    }
}
