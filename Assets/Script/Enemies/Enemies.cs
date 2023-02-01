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

    [SerializeField] private bool isDead = false;

    public float damage;

    AudioSource audioRaptor;

    public PlayerHealth playerHealth;

    private Animator animeRaptor;
    
    void Start()
    {
         
        animeRaptor = GetComponent<Animator>();
        Raptor = GetComponent<NavMeshAgent>();
        audioRaptor = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        float distanceTarget = Vector3.Distance(Target.position, transform.position);

        if (distanceTarget < chase && distanceTarget > attackRange)
        {
            Chase();

        }
        if (distanceTarget < attackRange)
        {
            attack();
        }


    }

    void Chase()
    {

        animeRaptor.SetBool("isRunning", true);
        Raptor.destination = Target.position;
    }


    void attack()
    {
        Raptor.destination = Target.position;

        if(Time.time > attackTime)
        {
            animeRaptor.SetBool("Attack", true);
            playerHealth.playerHurt(10);
            attackTime = Time.time + attackRepeat;
        }
    }

    public void Dead()
    {
        isDead = true;
        animeRaptor.SetBool("isDead", true);
        Destroy(transform.gameObject, 5);
    }

}