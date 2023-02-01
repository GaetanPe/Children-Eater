using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    //float time;

    public Transform Target;
    public NavMeshAgent Raptor;

    public float lookRadius;

    public float chase = 10;

    public float attackRange = 2.2f;

    public float attackRepeat = 1;
    private float attackTime;

    public float damage;

    AudioSource audioRaptor;

    private Animator animeRaptor;
    
    void Start()
    {
         
        animeRaptor = GetComponent<Animator>();
        Raptor = GetComponent<NavMeshAgent>();
        audioRaptor = GetComponent<AudioSource>
        attackTime = attackTime.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        Raptor = GameObject.Find("Player").transform;
       
        float distanceTarget = Vector3.Distance(Target.position, transform.position);
        if (distanceTarget > lookRadius)
        {
            idle();
        }

        if (distanceTarget < chase && distanceTarget > attackRange)
        {
            chase();

        }
        if (distanceTarget < attackRange)
        {
            attack();
        }


    }

    void chase()
    {

        animeRaptor.SetBool("isRunning");
        Raptor.destination = Target.position;
    }

    void idle()
    {
        animeRaptor.play("idle");
    }

    void attack()
    {
        Raptor.destination = Target.position;

        if(Time.time > attackTime)
        {
            animeRaptor.SetBool("Attack");
            Target.GetCompenent<PlayerInventory>.ApplyDammage(damage);
            attackTime = Time.time + attackRepeat;
        }
    }

    public void Dead()
    {
        isDead = true;
        animeRaptor.SetBool("isDead");
        Destroy(transform.gameObject, 5);
    }

}