using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectingScript : MonoBehaviour
{
     public void Map1 ()
    {
        SceneManager.LoadScene(1);

    }
    public void Map2 ()
    {
        SceneManager.LoadScene(2);
    }

    public void Map3 ()
    {
        SceneManager.LoadScene(3);
    }

    public void Map4 ()
    {
        SceneManager.LoadScene(4);
    }

    public void Map5 ()
    {
        SceneManager.LoadScene(5);
    }
}
