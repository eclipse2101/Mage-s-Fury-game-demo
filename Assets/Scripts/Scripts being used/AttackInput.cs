using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : MonoBehaviour
{
    RevampedCharacterController playerScript;

    public GameObject hand1;
    public GameObject hand2;
    public float hitTimer = 0.05f; 
    Animator animationRunnerA;
    // Start is called before the first frame update
    void Awake()
    {
        playerScript = GetComponent<RevampedCharacterController>();
    }

    void Start()
    {
        animationRunnerA = GetComponent<Animator>();
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
                StartCoroutine(AttackReset());

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

    IEnumerator AttackReset()
    {
        yield return new WaitForSeconds(hitTimer);
        playerScript.hitCount = 0;
        animationRunnerA.SetInteger("punches", 0);
    }
}
