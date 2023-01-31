using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    //float time;

    public Transform Target;
    public float lookRadius;


    //private bool isDead = false;

    public float chaseRange = 10;

    public float attackRange = 2.5f;

    // public float attackReapeatTime = 1;
    // private float attackTime;

    // public float TheDamage;

    public NavMeshAgent Raptor;

    //AudioSource audioRaptor;

    private Animator animRaptor;
    // Start is called before the first frame update
    void Start()
    {

        animRaptor = GetComponent<Animator>();
        Raptor = GetComponent<NavMeshAgent>();
        //audioRaptor = GetComponent<AudioSource>();
        // time = 0;

        // animRaptor = gameObject.GetComponent<Animator>();
        // attackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        //Raptor.destination = Target.position;
        //Target = GameObject.Find("Player").transform;
        float distanceTarget = Vector3.Distance(Target.position, transform.position);
        if (distanceTarget <= lookRadius)
        {
            Raptor.isStopped = false;
        }

        if (Raptor.remainingDistance > lookRadius)
        {
            Raptor.speed = 0f;
            animRaptor.SetBool("stay", true);
            animRaptor.SetBool("isChasing", false);

        }
        else
        {
            Raptor.speed = 4f;
            animRaptor.SetBool("stay", false);
            animRaptor.SetBool("isChasing", true);
            animRaptor.SetBool("isCalling", true);
            Raptor.SetDestination(Target.position);
        }


    }



    // void chase()
    // {

    //     animRaptor.Play("Run");
    //     Raptor.destination = Target.position;
    // }

    // void attack()
    // {
    //     raptor.destination = transform.position;

    //     if(Time.time > attackTime)
    //     {
    //         animRaptor.Play("Bite");
    //         /*Target.GetComponent<PlayerInventory>().ApplyDamage(TheDamage);
    //         Debug.Log("The raptor send " + TheDamage + " pv.");
    //         attackTime = Time.time + attackReapeatTime;*/
    //     }
    // }


    // void call()
    // {
    //     animRaptor.Play("Call");
    // }

    /*public void ApplyDamage(float TheDamage)
    {
        if(!isDead)
        {
            enemyHealth = enemyHealth - TheDamage;
            print(gameObject.name + " a subit " + TheDamage + " pv.");
            if(enemyHealth <= 0)
            {
                Dead();
            }
        }
        
    }
    public void Dead()
    {
        isDead = true;
        animations.Play("Death");
        Destroy(transform.gameObject, 5);
    }*/
}