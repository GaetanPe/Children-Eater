using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Children : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent Child;

    //Distance between the player and the child
    public float distance = 5;

    public Animator animChildren;
    // Start is called before the first frame update
    void Start()
    {
        //animeChildren = GetComponent<Animator>();
        Child = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTarget = Vector3.Distance(Target.position, transform.position);

        //The player found a child
        if (distanceTarget < distance)
        {
            //animeChildren.SetBool("isFinding", true);
        }
    }
}
