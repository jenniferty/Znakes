using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Slider changes the green health bar
    public Slider slider;

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
