using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHp= 3; 
    public float speed; 
    Rigidbody badGuyRb; 
    public GameObject player; 

     
    
    // Start is called before the first frame update
    void Start()
    {
        badGuyRb = GetComponent<Rigidbody>();
        // player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        badGuyRb.AddForce( lookDirection * speed);
        
        
        if(EnemyHp == 0)
        {
            Destroy(gameObject);
        }
        /*
        if(transform.position.y < 10f)
        {
          Destroy(gameObject);
        }
        */
    }
}
