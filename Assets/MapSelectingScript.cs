using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelectingScript : MonoBehaviour
{
    public void Map1 ()
    {
        SceneChanger.LoadScene("Map1");
    }

    public void Map2 ()
    {
        SceneChanger.LoadScene("Map2");
    }

    public void Map3 ()
    {
        SceneChanger.LoadScene("Map3");
    }

    

}
