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
        energyBar.setMaxEnergy(currentEnergy);
        InvokeRepeating("Decrement", 0, 5);//used to called the function decrement every five seconds
    }

    //this function permit to decrease the player  energy 
    void Decrement()
    {
        if(!animator.GetBool("isDeath"))
        {
            currentEnergy--;
            energyBar.setEnergy(currentEnergy);
        }
        
    }
}
