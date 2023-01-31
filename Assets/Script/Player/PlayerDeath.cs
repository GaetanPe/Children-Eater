using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public EnergyBar energyBar;
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.getHealth() == 0 || staminaBar.getStamina() == 0 || energyBar.getEnergy()==0)
        {
            playerAnimator.SetBool("isDeath", true);
        }
    }
}
