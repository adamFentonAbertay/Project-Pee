using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public float GetHealth()
    {
        return slider.value;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


}
