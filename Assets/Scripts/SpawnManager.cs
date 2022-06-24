using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float spawnRate = 5f;

    [SerializeField]
    private Transform[] spawnPositions;

    [SerializeField]
    private GameObject[] spawnObjects;

    private float nextSpawnTime = 0f;

    private TimeManager timeManager;

    private void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
    }
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime && !timeManager.gameOver && !timeManager.gameFinished)
        {
            nextSpawnTime += spawnRate;
            SpawnObject(spawnObjects[RandomSpawnObject()], spawnPositions[RandomSpawnPosition()]);
            print("spawwn");
        }
    }

    private void SpawnObject(GameObject objectToSpawn, Transform newTransform)
    {
        Instantiate(objectToSpawn, newTransform.position, newTransform.rotation);
        
    }

    private int RandomSpawnPosition()
    {
        return Random.Range(0, spawnPositions.Length);
    }

    private int RandomSpawnObject()
    {
        return Random.Range(0, spawnObjects.Length);
    }
}
