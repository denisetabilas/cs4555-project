using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{
    public float health = 10;

    private Animator anim;
    public Transform player;
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;

    // Idle
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    // Attack
    public float timeBetweenAttacks=5;
    public bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerInSight, playerInAttack;

    void Awake () {
        anim = gameObject.GetComponentInChildren<Animator>();
        player = GameObject.Find("Third Person Player").transform;
        agent = GetComponent<NavMeshAgent>();
    } 

    void Idle() {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToPoint = transform.position - walkPoint;

        if (distanceToPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }

    void SearchWalkPoint() {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)){
            walkPointSet = true;
        }
    }

    void Chase() {
        agent.SetDestination(player.position);
    }

    void Attack() {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked){
            alreadyAttacked = true;
               FindObjectOfType<LotosPlayer>().TakeDamage(1);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack() {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Invoke(nameof(DestroyOpponent), 0.5f);
        }
    }

    void DestroyOpponent() {
        Destroy(gameObject);
    }

    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSight && !playerInAttack) Idle();
        if(playerInSight && !playerInAttack){
            anim.SetInteger("AnimParm", 1);
            Chase();
        }
        if(playerInSight && playerInAttack) Attack();        
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
