using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
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

    void playerHurt (float damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
