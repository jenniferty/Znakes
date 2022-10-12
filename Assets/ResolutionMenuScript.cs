using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResolutionMenuScript : MonoBehaviour
{

    public Dropdown resolitionDropdown;

    Resolution[] resolutions;

    //to get the resolution of the computer the game is running on 
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        (
            String option = resulutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        )

        resolutionDropdown.AddOptions(options);

    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
