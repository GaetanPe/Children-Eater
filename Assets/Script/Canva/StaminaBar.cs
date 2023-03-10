using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public Slider slider;

    //for reset stamina 
    public void setMaxStamina(float maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }

    //for set current stamina 
    public void setStamina(float stamina)
    {
        slider.value = stamina;
    }

    public float getStamina() 
    {
        return slider.value;
    }
}
