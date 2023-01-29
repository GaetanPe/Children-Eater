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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.setMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //this function allows to detect if the player is injured and if he is injured his life decreases.
    void playerHurt (float damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
