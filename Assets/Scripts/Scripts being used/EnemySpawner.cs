using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemies1;
    public GameObject enemies2;
   public float spawnarea1 = 10;
   public float spawnarea2 = 10;
   public int enemyCount;
   public int WaveNumber = 1; 
   
 
   
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(3);
        
    }

    // Update is called once per frame
    private Vector3 GenerateSpawnArea()
    {
        float rsax = Random.Range(spawnarea1, -spawnarea1);
        float rsaz = Random.Range(spawnarea2, -spawnarea2); 
        Vector3 randomPos =  new Vector3( rsax, 0, rsaz);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesSpawnNumber)
    {
       for (int i = 0; i < enemiesSpawnNumber; i++)
       {
          Instantiate(enemies1, GenerateSpawnArea(), enemies1.transform.rotation);
          Instantiate(enemies2, GenerateSpawnArea(), enemies2.transform.rotation);
       }

       WaveNumber ++; 
    }

    void Update()
    {
       enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0) 
        {
            SpawnEnemyWave(WaveNumber);
           
        }
    }
}
