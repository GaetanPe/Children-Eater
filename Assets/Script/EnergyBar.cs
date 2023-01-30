using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    //for reset energy 
    public void setMaxEnergy(float maxEnergy)
    {
        slider.maxValue = maxEnergy;
        slider.value = maxEnergy;
    }

    //for get current energy 
    public void setEnergy(float energy)
    {
        
        slider.value = energy;
    }
    
    public float getEnergy() 
    {
        return slider.value;
    }
}