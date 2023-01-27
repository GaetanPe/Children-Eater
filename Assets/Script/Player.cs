using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //for return rigidbody of player 
    Rigidbody playerRb;

    //speed of player on different states 
    public float speedWalk;
    public float speedRun;
    public float speedRotate;
    public float horizontal;
    public float vertical;

    //for the jump height
    public Vector3 jumpHeight;

    //for return the capsule collider of player
    CapsuleCollider playerCollider;

    //for return the Animator of player
    Animator playerAnimator;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        playerAnimator = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalk();
        PlayerRun();
    }


    void PlayerWalk()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speedWalk * vertical * Time.deltaTime);
        transform.Translate(Vector3.forward * speedWalk * horizontal * Time.deltaTime);
        transform.Rotate(Vector3.up * speedRotate * Time.deltaTime * horizontal);

        if (horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0)
        {
            playerAnimator.SetBool("isWalking", true);

        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

    }

    void PlayerRun()
    {
        if (horizontal == Input.GetAxis("Horizontal")  && Input.GetKey(KeyCode.LeftShift))
        {
     
            transform.Translate(Vector3.forward * speedRun * horizontal * Time.deltaTime);
            playerAnimator.SetBool("isRunning", true);
        }
        if(vertical == Input.GetAxis("Vertical") && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * speedRun * horizontal * Time.deltaTime);
            playerAnimator.SetBool("isRunning", true);

        }
        else
        {

            playerAnimator.SetBool("isRunning", false);
        }
    }

    void PlayJump()
    {
        bool jump = false;

    }

}
