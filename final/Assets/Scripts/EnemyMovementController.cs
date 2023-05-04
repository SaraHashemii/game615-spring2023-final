using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{

    private NavMeshAgent agent = null;
    private Transform target;
    private float distanceToPlayer;
    private bool hasStopped = false;

    [SerializeField] private float LastAttackTime = 0f;
    [SerializeField] private AudioSource attackAudio;
    [SerializeField] private ParticleSystem attackParticle;

    private EnemyHealthController enemyHealthController = null;


    private void Start()
    {
        GetRefrences();
        this.attackAudio.playOnAwake = false;
    }

    private void Update()
    {
        MoveToPlayer();
    }


    private void GetRefrences()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerMovementController.instance.GetComponent<Transform>();
        enemyHealthController = GetComponent<EnemyHealthController>();

    }

    private void MoveToPlayer()
    {

        RotateToTarget();

        float distanceToPlayer = Vector3.Distance(target.position, transform.position);
        {

            agent.SetDestination(target.position);



            if (distanceToPlayer <= agent.stoppingDistance)
            {
                if (!hasStopped)
                {
                    hasStopped = true;
                    LastAttackTime = Time.time;
                }

                if (Time.time >= LastAttackTime + enemyHealthController.attackSpeed)
                {
                    LastAttackTime = Time.time;
                    HealthManager targetHealth = target.GetComponent<HealthManager>();
                    AttackPlayer(targetHealth);
                    attackAudio.Play();
                    Vector3 particleSpawnPos = new Vector3(this.transform.position.x, this.transform.position.y + .85f, this.transform.position.z);
                    Instantiate(attackParticle, particleSpawnPos, this.transform.rotation);
                }

            }
            else
            {
                if (hasStopped)
                {
                    hasStopped = false;
                }
            }
        }


    }

    private void RotateToTarget()
    {

        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }


    private void AttackPlayer(HealthManager damage)
    {
        enemyHealthController.HandleDamge(damage);
    }
}
