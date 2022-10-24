using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    //Slider changes the orange stamina bar
    public Slider slider;
    public PlayerController playerController;

    private float stamina = 100f;
    private float staminaMax = 100f;
    private float staminaDecreasePerFrame = 40f;
    private float staminaIncreasePerFrame = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        Debug.Log("Inside Stamina Bar");
        SetStaminaMax();
    }

    private void Update()
    {
       if(this.stamina == 0)
        {
            playerController.SetHasStamina(false);
        }
        else
        {
            playerController.SetHasStamina(true);   
        }
    }

    public void SetStaminaSlider(float stamina)
    {
        slider.value = stamina;
    }

    public void UpdateStamina()
    {
        if (playerController.getIsSprinting())
        {
            Debug.Log("stamina -- " + stamina);
            stamina = Mathf.Clamp(stamina - (staminaDecreasePerFrame * Time.deltaTime), 0.0f, staminaMax);
        }
        else if (stamina < staminaMax)
        {
            Debug.Log("stamina ++ "+stamina);
            stamina = Mathf.Clamp(stamina + (staminaIncreasePerFrame * Time.deltaTime), 0.0f, staminaMax);
        }
        Debug.Log("Stamina Updated");
        SetStaminaSlider(stamina);
    }

    public void SetStaminaMax()
    {
        this.stamina = this.staminaMax;
    }

}
