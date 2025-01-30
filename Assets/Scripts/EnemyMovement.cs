using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target;

    private NavMeshAgent agent;

    private Vector3 destination;

    private Animator animator;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agent.SetDestination(destination);
    }


    public void Die(bool death)
    {
        ChangeTarget();
        animator.SetBool("Die", death);
    }


    private void ChangeTarget()
    {
        destination = transform.position;
    }
}
