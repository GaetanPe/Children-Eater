using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    //for reset health 
    public void setMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    //for get current health 
    public void setHealth(float health)
    {
        slider.value =  health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public float getHealth() 
    {
        return slider.value;
    }
}
