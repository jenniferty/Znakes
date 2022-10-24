using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static Stack<string> sceneHistory = new Stack<string>();
    private AudioManager audioManager;
    public PlayerHealth playerHealth;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public static void LoadScene(string newScene)
    {
        sceneHistory.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(newScene);
    }

    public void PreviousScene()
    {
        audioManager.playGameStopMenuTheme();
        playerHealth.setSnakeHealth(playerHealth.getSnakeMaxHealth());
        SceneChanger.LoadScene(sceneHistory.Peek());
    }
}
