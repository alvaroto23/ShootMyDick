using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private GameObject Alien;

    private int aliensSpawned;

    private void Update()
    {
        if (aliensSpawned <= 10)
        {
            StartCoroutine(Spawner());
        }
        
    }

    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(5);
        Instantiate(Alien);
        aliensSpawned++;
    }
}
