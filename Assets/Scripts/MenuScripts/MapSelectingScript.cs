using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectingScript : MonoBehaviour
{
    private AudioManager audioManager;
    public ObjectSpawnLocation location;
    public PlayerHealth playerHealth;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        location = FindObjectOfType<ObjectSpawnLocation>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    public void Map1 ()
    {
        audioManager.playGameStopMenuTheme();
        location.setMapIndex(1);
        playerHealth.setSnakeHealth(playerHealth.getSnakeMaxHealth());
        SceneChanger.LoadScene("Map1");
    }

    public void Map2 ()
    {
        audioManager.playGameStopMenuTheme();
        location.setMapIndex(2);
        playerHealth.setSnakeHealth(playerHealth.getSnakeMaxHealth());
        SceneChanger.LoadScene("Map2");
    }

    public void Map3 ()
    {
        audioManager.playGameStopMenuTheme();
        location.setMapIndex(3);
        playerHealth.setSnakeHealth(playerHealth.getSnakeMaxHealth());
        SceneChanger.LoadScene("Map3");
    }
}
