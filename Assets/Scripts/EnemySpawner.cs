using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnLocation;
    public GameObject enemyAI;

    private void Start()
    {
        spawnLocation = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(StartSpawingEnemy());
    }

    IEnumerator StartSpawingEnemy()
    {
        SpawnEnemy(3);
        yield return new WaitForSeconds(30);
        SpawnEnemy(3);
    }

    private void SpawnEnemy(int noOfEnemyToSpawn)
    {
        if (spawnLocation != null)
        {
            for (int i = 1; i <= noOfEnemyToSpawn; i++)
            {
                int randomSpawnPointNo = Random.Range(0, spawnLocation.Length - 1);
                Instantiate(enemyAI, spawnLocation[randomSpawnPointNo].transform.position, spawnLocation[randomSpawnPointNo].transform.rotation);
            }
        }
    }
}
