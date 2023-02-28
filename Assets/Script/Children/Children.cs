using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Children : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Child;
    private GameObject isSaved;

    //Distance between the player and the child
    public float distance = 3;

    public Animator animChildren;
    // Start is called before the first frame update
    void Start()
    {
        animChildren = GetComponent<Animator>();
        Child = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTarget = Vector3.Distance(Target.position, transform.position);

        //The player found a child
        if (distanceTarget < distance)
        {
            animChildren.SetBool("isFinding", true);

        }


    }

    //contact between the player and a child
    void OnTriggerExit(collider collidChild)
    {
        if (collidChild.gameObject.CompareTag("Child"))
        {
            isSaved = collidChild.gameObject;
        }
    }

}
