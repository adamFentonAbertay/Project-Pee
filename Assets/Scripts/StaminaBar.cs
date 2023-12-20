using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public float refreshRate = 1;
    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }

    public float GetStamina()
    {
        return slider.value;
    }

    public void SetMaxStamina(float stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }
    //


    void Update() {
        if (slider.value < 100)
        {
            slider.value += refreshRate * Time.deltaTime;
        }

        if (slider.value < 0)
        {
            slider.value = 0;
        }
    }


}
