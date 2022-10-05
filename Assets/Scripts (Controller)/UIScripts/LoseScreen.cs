using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    public GameObject deathOverlay;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ShowDeathScreen()
    {
        deathOverlay.SetActive(true);
    }
}
