using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject destroyObject;
    public Rigidbody playerRb;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player") && playerMovement.isGrounded == false)
        {
            Destroy(destroyObject);
            playerRb.AddForce(new Vector3(0, 30, 0), ForceMode.Impulse);
        }
    }

}
