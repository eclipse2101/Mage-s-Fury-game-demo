using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
    private EnemySpawner SpawnerScript;

    void Awake()
     {
       SpawnerScript = GameObject.Find("enemy spawner").GetComponent<EnemySpawner>();
     }

    void OnTriggerEnter(Collider other)
    {
       SpawnerScript.GameOver();
       Destroy(other.gameObject); 
       Debug.Log("game over! You Suck");
    }
       
}
