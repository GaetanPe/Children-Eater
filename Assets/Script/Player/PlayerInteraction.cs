using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInteraction : MonoBehaviour
{
    public EnergyBar energyBar;
    [SerializeField] private bool interact = false;
    [SerializeField] private float restoreEnergy = 5f;
    [SerializeField] private float currentEnergy;
    private GameObject interactObject;

    void OnTriggerEnter(Collider collider)
    {
        interact = true;
        if (collider.gameObject.CompareTag("Food"))
        {
            interactObject = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Food"))
        {
            interactObject = null;
            interact = false;
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactObject != null && interact)
        {
            currentEnergy = energyBar.getEnergy();
            currentEnergy += restoreEnergy;
            energyBar.setEnergy(currentEnergy);
            interactObject.SetActive(false);
        }
    }
}
