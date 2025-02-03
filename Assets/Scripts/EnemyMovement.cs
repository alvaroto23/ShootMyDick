using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private EnemySpawner spawner;

    public int hits = 0;
    private Vector3 destination;

    private void Awake()
    {
        target = GetComponentInParent<EnemySpawner>().player;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        spawner = GetComponentInParent<EnemySpawner>();
    }

    private void Update()
    {
        // Cambia el destino si ha muerto o no
        if (hits < 2)
        {
            destination = target.position;
        }
        else if (hits >= 2)
        {
            destination = transform.position;
            agent.SetDestination(destination);
            StartCoroutine(Die());

        }

        agent.SetDestination(destination);
    }

    public void ReceiveHit()
    {
        hits++;
        print("Alien ha recibido " + hits + " disparos");
    }

    private IEnumerator Die()
    {
        animator.SetBool("Die", true);
        spawner.aliensSpawned--;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

}
