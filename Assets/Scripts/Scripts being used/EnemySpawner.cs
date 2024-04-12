using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    float SpawnRangeX = 20;
    float spawnPosZ = 35;
    float randomSpawnRangeZ = 14;
    public float startingSpawn = 5; 
    public float spawnTiming = 1.5f;
    float generatorNumber; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startingSpawn, spawnTiming);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()

    {
        generatorNumber = Random.Range(1,3);

        if (generatorNumber == 1)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, spawnPosZ); 
            
            int animalIndex = Random.Range(0, animalPrefabs.Length); 
            
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        }

        if (generatorNumber == 2)
        {
          Vector3 spawnPos = new Vector3(-25, 0, Random.Range(-randomSpawnRangeZ, randomSpawnRangeZ)); 
            
            int animalIndex = Random.Range(0, animalPrefabs.Length); 
            
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));

        }

        if (generatorNumber == 3)
        {
          Vector3 spawnPos = new Vector3(25, 0, Random.Range(-randomSpawnRangeZ, randomSpawnRangeZ)); 
            
            int animalIndex = Random.Range(0, animalPrefabs.Length); 
            
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0));
            
        }
    }
}
