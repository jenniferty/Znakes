using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static Stack<string> sceneHistory = new Stack<string>();

     public static void LoadScene(string newScene)
    {
        sceneHistory.Push(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(newScene);
    }

    public void PreviousScene()
    {
            SceneChanger.LoadScene(sceneHistory.Peek());
    }

}
