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
    [SerializeField] private GameObject foodText;
    private GameObject interactObject;

    private void Start()
    {
        foodText.SetActive(false);
    }
    void OnTriggerEnter(Collider collider)
    {
        interact = true;
        if (collider.gameObject.CompareTag("Food"))
        {
            interactObject = collider.gameObject;
            foodText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Food"))
        {
            interactObject = null;
            interact = false;
            foodText.SetActive(false);

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
