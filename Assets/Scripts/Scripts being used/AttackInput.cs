using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    RevampedCharacterController playerScript;
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
            Debug.Log("found it");
            if(Input.GetMouseButtonDown(0))
            {
                playerScript.Attacking();
            }
        }
        
    }
}
