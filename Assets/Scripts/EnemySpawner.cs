using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private GameObject Alien;
    private int maxAliens = 10;
    public int aliensSpawned = 0;

    // Inicia el spawneo
    private void Start()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-30, 30), Random.Range (1, 20), Random.Range(-30, 30));
        Instantiate(Alien, spawnPos, Quaternion.identity, transform);
        StartCoroutine(Spawner()); 
    }

    // Spawneo en pos aleatoria cada 5 seg
    private IEnumerator Spawner()
    {
        while (aliensSpawned < maxAliens)
        {
            yield return new WaitForSeconds(3);
            Vector3 spawnPos = new Vector3(Random.Range(-30, 30), 1, Random.Range(-30, 30));
            Instantiate(Alien, spawnPos, Quaternion.identity, transform);
            aliensSpawned++;
        }
    }
}
