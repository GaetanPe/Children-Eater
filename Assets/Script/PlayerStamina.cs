using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float currentStamina;

    public StaminaBar staminaBar;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        currentStamina = maxStamina;
        staminaBar.setMaxStamina(currentStamina);
        InvokeRepeating("PlayerStatus", 0, 1);//used to called the function decrement every one seconds
    }

    void PlayerStatus() 
    {
        if(animator.GetBool("isRunning") && currentStamina > 0)
        {
            currentStamina--;
            staminaBar.setStamina(currentStamina);
        }
        if (!animator.GetBool("isRunning") && currentStamina != maxStamina)
        {
            currentStamina++;
            staminaBar.setStamina(currentStamina);
        }
    }
}
