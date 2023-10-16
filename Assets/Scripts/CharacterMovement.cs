using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6f;
    public float hInput; 
    public float vInput; 
    public CharacterController  player; // think of this as the motor that controls our player 
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // BASIC CHARACTER MOVEMENT//
        hInput = Input.GetAxisRaw("Horizontal"); 
        vInput = Input.GetAxisRaw("Vertical");
       
        /*
        GetAxisRaw is pretty much the same as GetAxis but without the input smoothing
        */
        Vector3 direction = new Vector3(hInput, 0f, vInput).normalized; // this is to mnake sure that when you press 2 buttons you dont move faster.

        if (direction.magnitude >= 0.1f)
        {
           player.Move(direction * speed * Time.deltaTime);
        }
        
    }
}
