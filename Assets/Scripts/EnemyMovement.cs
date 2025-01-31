using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;

    public int hits = 0;
    private bool dead;
    private Vector3 destination;

    private void Awake()
    {
        target = GetComponentInParent<EnemySpawner>().player;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (dead == false)
        {
            destination = target.position;
        }
        else if (dead)
        {
            destination = transform.position;
        }

        agent.SetDestination(destination);
    }

    public void ReceiveHit()
    {
        hits++;
        print("Alien ha recibido " + hits + " disparos");
    }

    public void Die(bool death)
    {
        dead = true;
        animator.SetBool("Die", death);
    }
}
