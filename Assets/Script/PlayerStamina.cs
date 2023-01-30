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
        InvokeRepeating("PlayerStatus", 0, 0.2f);//used to called the function decrement every 0,2 seconds
    }

    void PlayerStatus() 
    {
        if(animator.GetBool("isRunning") && currentStamina > 0)
        {
            currentStamina--;
            staminaBar.setStamina(currentStamina);
        }
        if (!animator.GetBool("isRunning") && currentStamina != maxStamina && !animator.GetBool("isDeath"))
        {
            currentStamina++;
            staminaBar.setStamina(currentStamina);
        }
    }
}
