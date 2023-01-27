using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : MonoBehaviour
{
    public float Distance;

    private bool isDead = false;

    public Transform Target;

    public float chaseRange = 10;

    public float attackRange = 2.5f;

    public float attackReapeatTime = 1;
    private float attackTime;

    public float TheDamage;

    public NavMeshAgent raptor;

    private Animator animations;
    // Start is called before the first frame update
    void Start()
    {

        raptor = gameObject.GetComponent<NavMeshAgent>();
        animations = gameObject.GetComponent<Animator>();
        attackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Target = GameObject.FindWithTag("Player").transform;
            Distance = Vector3.Distance(Target.position, transform.position);

            //When the enemy is near 
            if (Distance > chaseRange)
            {
                idle();
            }

            if (Distance < chaseRange && Distance > attackRange)
            {
                chase();
            }

            if (Distance < attackRange)
            {
                attack();
            }
        }
       
    }

    void chase()
    {
        animations.Play("run");
        raptor.destination = Target.position;
    }

    void attack()
    {
        raptor.destination = transform.position;

        if(Time.time > attackTime)
        {
            animations.Play("bite");
            /*Target.GetComponent<PlayerInventory>().ApplyDamage(TheDamage);
            Debug.Log("The raptor send " + TheDamage + " pv.");
            attackTime = Time.time + attackReapeatTime;*/
        }
    }

    void idle()
    {
        animations.Play("idle");
    }

    void call()
    {

    }

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
        animations.Play("die");
        Destroy(transform.gameObject, 5);
    }*/
}
