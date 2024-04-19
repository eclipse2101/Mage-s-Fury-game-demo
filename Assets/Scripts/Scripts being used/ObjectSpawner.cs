using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
    public bool enemyspawner = false; 
    public GameObject[] animalPrefabs;
    float SpawnRangeX = 30;
    // float spawnPosZ = 30;
    float randomSpawnRangeZ = 14;
    public float startingSpawn = 5; 
    public float spawnTiming = 1.5f;
    float generatorNumber;
    public TextMeshProUGUI gameOverScreen;
    public GameObject enemies;
   public int enemyCount;
   public int WaveNumber = 1; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(enemyspawner = false)
        {
          InvokeRepeating("SpawnRandomAnimal", startingSpawn, spawnTiming);
        }
        else
        {
            SpawnEnemyWave(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyHealth>().Length;
        if (enemyCount == 0) 
        {
            SpawnEnemyWave(WaveNumber);
           
        }
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

    private Vector3 GenerateSpawnArea()
    {
        float rsax = Random.Range(SpawnRangeX, -SpawnRangeX);
        float rsaz = Random.Range(SpawnRangeX, -SpawnRangeX); 
        Vector3 randomPos =  new Vector3( rsax, 2, rsaz);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesSpawnNumber)
    {
       for (int i = 0; i < enemiesSpawnNumber; i++)
       {
          Instantiate(enemies, GenerateSpawnArea(), enemies.transform.rotation);
       }
    }
    
    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
    }
}
