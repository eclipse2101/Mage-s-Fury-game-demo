using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    float SpawnRangeX = 30;
    // float spawnPosZ = 30;
    float randomSpawnRangeZ = 14;
    public float startingSpawn = 5; 
    public float spawnTiming = 1.5f;
    float generatorNumber;
    public TextMeshProUGUI gameOverScreen;
    
    
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
        generatorNumber = Random.Range(1,4);

        if (generatorNumber == 1)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, 40); 
            
            int animalIndex = Random.Range(0, animalPrefabs.Length); 
            
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 180, 0));
        }

        if (generatorNumber == 2)
        {
          Vector3 spawnPos = new Vector3(-40, 0, Random.Range(-randomSpawnRangeZ, randomSpawnRangeZ)); 
            
            int animalIndex = Random.Range(0, animalPrefabs.Length); 
            
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));

        }

        if (generatorNumber == 3)
        {
          Vector3 spawnPos = new Vector3(40, 0, Random.Range(-randomSpawnRangeZ, randomSpawnRangeZ)); 
            
            int animalIndex = Random.Range(0, animalPrefabs.Length); 
            
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0));
            
        }

        if (generatorNumber == 4)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, -40); 
            
            int animalIndex = Random.Range(0, animalPrefabs.Length); 
            
            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, -180, 0));
        }
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
    }
}
