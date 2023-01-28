using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //for return rigidbody of player 
    Rigidbody playerRigidbody;

    //speed of player on different states 
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;


    //for get value to move our Player  
    Vector3 playerMovement = Vector3.zero;

    //for check if the player jump
    private bool isGrounded;

    //for return the Animator of player
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>(); 
    }

    // Update is called once per frame

    void Update()
    {
        PlayerJump();
    }


    void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        // Get input axis for horizontal and vertical movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    
        // Calculate player movement based on input and walk speed
        if(Input.GetKey(KeyCode.LeftShift) )
        {
            playerMovement = new Vector3(horizontal, 0, vertical) * runSpeed * Time.deltaTime;
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerMovement = new Vector3(horizontal, 0, vertical) * walkSpeed * Time.deltaTime;
            playerAnimator.SetBool("isWalking", playerMovement.magnitude != 0f);
            playerAnimator.SetBool("isRunning", false);

        }
        
        // Move player based on calculated movement
        playerRigidbody.MovePosition(transform.position + playerMovement);
        
        // Check if player is moving and update player rotation
        if (playerMovement.magnitude != 0f)
        {
            transform.LookAt(transform.position + playerMovement);
        }
    }

    void PlayerJump()
    {
        if ( Input.GetButtonDown("Jump") && isGrounded) // If the user presses the space key and the character is on the ground.
        {
            playerAnimator.SetBool("isJump", true);
            playerRigidbody.AddForce(new Vector3(0, 11, 0), ForceMode.Impulse); // add a jump force at player 
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // If the character collides with an object tagged "Ground"
        {
            isGrounded = true; // The character is no longer jumping.
            playerAnimator.SetBool("isJump", false);
        }
    }
}