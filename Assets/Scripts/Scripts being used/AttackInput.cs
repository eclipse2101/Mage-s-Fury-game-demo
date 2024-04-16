using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    RevampedCharacterController playerScript;

    public GameObject hand1;
    public GameObject hand2;
    public int hitTimer = 3; 
    // Start is called before the first frame update
    void Awake()
    {
        playerScript = GetComponent<RevampedCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript != null)
        {
            //Debug.Log("found it");
            if(Input.GetMouseButtonDown(0))
            {
                playerScript.Attacking();
                hitTimer = 3;
            }
            /*
            if (playerScript.hitCount >= 1)
            {
                hitTimer = hitTimer - 1;
            }

            if (hitTimer == 0)
            {
                playerScript.hitCount = 0;
            }
            */
        }
        
    }
}
