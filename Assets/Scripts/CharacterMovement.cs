using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6f;
    public float hInput; 
    public float vInput;  
    
    
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
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * hInput);
    
    
    
    
    
    
    
    }
}
