using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
   
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    //called HealthBar Class
    public HealthBar healthBar;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        healthBar.setMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //this function allows to detect if the player is injured and if he is injured his life decreases if the player is not death .
    public void playerHurt (float damage)
    {
        if(!animator.GetBool("isDeath"))
        {
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
        }
       
    }
}
