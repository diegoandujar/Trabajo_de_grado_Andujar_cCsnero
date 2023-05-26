using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{

    public Slider slider;
    
    public void Setmaxvalue(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        Debug.Log("max value = " + slider.maxValue);
    }

    public void UpdateHealthbar(int health)
    {
        slider.value = health;
    }

}
