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


    //to choose directional key in Unity
    public string inputFront;
    public string inputBack;
    public string inputLeft;
    public string inputRight;
    public string inputJump;

    //for the jump height
    public Vector3 jumpHeight;

    //for return the capsule collider of player
    CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(inputFront))
        {
            transform.Translate(0,0,speedWalk * Time.deltaTime);
        }

        if(Input.GetKey(inputBack))
        {
            transform.Translate(0,0,-(speedWalk/2) * Time.deltaTime);
        }

        if(Input.GetKey(inputLeft))
        {
            transform.Rotate(0,-speedRotate * Time.deltaTime,0);
        }

        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, speedRotate * Time.deltaTime, 0);
        }
    }
}
