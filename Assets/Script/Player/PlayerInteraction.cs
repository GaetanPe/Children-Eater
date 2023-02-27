using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInteraction : MonoBehaviour
{
    public EnergyBar energyBar; 
    [SerializeField] private float restoreEnergy = 5f;
    [SerializeField] private float currentEnergy;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Food"))
        {
            currentEnergy = energyBar.getEnergy();
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                currentEnergy  += restoreEnergy;
                energyBar.setEnergy(currentEnergy);
            }
        }
    }
}
