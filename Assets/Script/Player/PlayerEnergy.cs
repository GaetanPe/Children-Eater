using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private float maxEnergy = 100f;
    [SerializeField] private float currentEnergy;
    public EnergyBar energyBar;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentEnergy= maxEnergy +1f;
        InvokeRepeating("Decrement", 0, 3);//used to called the function decrement every tree seconds
    }

    //this function permit to decrease the player  energy 
    void Decrement()
    {
        if(!animator.GetBool("isDeath"))
        {
            currentEnergy = energyBar.getEnergy();
            currentEnergy--;
            energyBar.setEnergy(currentEnergy);

        }

    }
}
