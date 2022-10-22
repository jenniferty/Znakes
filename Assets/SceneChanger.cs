using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static Stack<string> sceneHistory = new Stack<string>();
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public static void LoadScene(string newScene)
    {
        sceneHistory.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(newScene);
    }

    public void PreviousScene()
    {
        audioManager.playGameStopMenuTheme();
        SceneChanger.LoadScene(sceneHistory.Peek());
    }
}
