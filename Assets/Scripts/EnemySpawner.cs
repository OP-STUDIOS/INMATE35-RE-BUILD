﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject[] spawnLocation;
    [SerializeField]
    private GameObject level1_enemyAI;
    [SerializeField]
    private GameObject level2_enemyAI;
    [SerializeField]
    private GameObject level3_enemyAI;

    [SerializeField]
    private int spawnFrequency = 20;
    [SerializeField]
    private int spawnCount = 3;

    private void Start()
    {
        spawnLocation = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(StartSpawingEnemy());
    }

    IEnumerator StartSpawingEnemy()
    {
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
        yield return new WaitForSecondsRealtime(spawnFrequency);
        SpawnEnemy(spawnCount);
    }

    private void SpawnEnemy(int noOfEnemyToSpawn)
    {
        if (spawnLocation != null)
        {
            for (int i = 1; i <= noOfEnemyToSpawn; i++)
            {
                int randomSpawnPointNo = Random.Range(0, spawnLocation.Length - 1);
                Instantiate(GenerateRandomEnemyNo(), spawnLocation[randomSpawnPointNo].transform.position, spawnLocation[randomSpawnPointNo].transform.rotation);
            }
        }
    }

    private GameObject GenerateRandomEnemyNo()
    {
        int randomNo = Random.Range(1, 100);
        if(randomNo >= 95)
        {
            return level3_enemyAI;
        }
        //5 % chance
        else if (randomNo <= 50 && randomNo >= 40)
        {
            return level2_enemyAI;
        }
        //10% chance
        else
        {
            return level1_enemyAI;
        }
        //85% chance
    }
}
