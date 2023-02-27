using UnityEngine;
using UnityEngine.AI;


public class Enemies : MonoBehaviour
{
    //float time;
    
    public Transform Target;
    public NavMeshAgent Raptor;

    public float lookRadius = 10f;

    public float chase = 10;

    public float attackRange = 2.2f;

    public float attackRepeat = 1;
    private float attackTime;


    public float damage;

    AudioSource audioRaptor;

    public PlayerHealth playerHealth;

    [SerializeField] private Animator playerAnimator;

    //[SerializeField] private Animator animeRaptor;
    
    void Start()
    {
         
        //animeRaptor = GetComponent<Animator>();
        Raptor = GetComponent<NavMeshAgent>();
        audioRaptor = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerAnimator.GetBool("isDeath"))
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
    }

    void Chase()
    {

        //animeRaptor.SetBool("isRunning", true);
        Raptor.destination = Target.position;
    }


    void attack()
    {
        Raptor.destination = Target.position;

        if(Time.time > attackTime)
        {
            //animeRaptor.SetBool("Attack", true);
            playerHealth.playerHurt(10);
            attackTime = Time.time + attackRepeat;
        }
    }

}