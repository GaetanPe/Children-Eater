using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Children : MonoBehaviour
{
    public ChildrenSaved childrenSaved;
    public Transform Target;
    public NavMeshAgent Child;
    [SerializeField] private GameObject childObject;

    //Distance between the player and the child
    public float distance = 3;

    //public Animator animChildren;
    // Start is called before the first frame update
    void Start()
    {
        Child = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTarget = Vector3.Distance(Target.position, transform.position);

        //The player found a child
        if (distanceTarget < distance)
        {
            Destroy(childObject);
            childrenSaved.childrenSavedCount++;
            //animChildren.SetBool("isFinding", true);
           
        }


    }

}
