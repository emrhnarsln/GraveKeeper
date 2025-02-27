using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 50;
    public float spawnInterval = 1f;
    private Timer time;
    private SceneChanger sceneChanger;
    // private Timer time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        time = FindObjectOfType<Timer>();
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float mobSpawnTime = time.timeRemaining;

        if (mobSpawnTime  <60 && mobSpawnTime > 45)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, 4)];
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        else if (mobSpawnTime <= 45 && mobSpawnTime > 30)
        {
            
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, 3)];
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        else if (mobSpawnTime <= 30 && mobSpawnTime > 15)
        {
            
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, 2)];
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        else
        {
            GameObject enemyPrefab = enemyPrefabs[0];
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }


    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}