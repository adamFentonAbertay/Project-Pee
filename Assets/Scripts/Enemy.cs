using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 50f;
    [SerializeField] private Renderer myObject;


    public NavMeshAgent agent;
    Transform player;
    public LayerMask WhatIsGround, WhatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float timeBetweenAttacks;
    bool alreadyAtacked;
     public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public GameObject projectile;

    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
        if (GameObject.FindGameObjectsWithTag("Player")[0])
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
            
        }
        else
        {
           // Debug.Log("waiting for first player");
        }
        
        //sight/attack range?
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInAttackRange && !playerInSightRange)
        {
           // Debug.Log("patrolling");
            Patrolling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
           // Debug.Log("chasing");
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
           // Debug.Log("attacking");
            AttackPlayer();
        }
    }





    private void Patrolling()
    {
        

        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;
            
            if (distanceToWalkPoint.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }
    }

    private void SearchWalkPoint()
    {
       
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, WhatIsGround))
        {
            Debug.Log("true i guess");
            walkPointSet = true;
        }
   

    }

    private void ChasePlayer()
    {
       
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
    
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!alreadyAtacked)
        {
            //attack
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);

            alreadyAtacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAtacked = false;
    }

    public void TakeDamage (float amount)
    {
       
        myObject.material.color = Color.white;
   
        health -= amount;
        if (health <= 0 )
        {
            Die();
        }

    }

  

    void Die()
    {
        Destroy(gameObject);
    }
}
