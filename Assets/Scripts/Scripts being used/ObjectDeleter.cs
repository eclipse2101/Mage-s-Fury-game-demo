using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeleter : MonoBehaviour
{
     private EnemySpawner SpawnerScript;
     private AudioSource buttonSound;
     public AudioClip deathSound;

    void Awake()
     {
       SpawnerScript = GameObject.Find("enemy spawner").GetComponent<EnemySpawner>();
     }

     void Start()
     {
           buttonSound = GetComponent<AudioSource>();
     }

    void OnTriggerEnter(Collider other)
    {
       SpawnerScript.GameOver();
       Destroy(other.gameObject); 
       Debug.Log("game over! You Suck");
       buttonSound.PlayOneShot(deathSound, 3.0f); 
    }
       
}