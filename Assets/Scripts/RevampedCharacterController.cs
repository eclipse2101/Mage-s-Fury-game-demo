using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // this makes sure your character has a character controller before starting the game

public class RevampedCharacterController : MonoBehaviour
{
    public CharacterController player; // think of this as the motor that controls our player 
    public float speed;
    private float direction; 
    public float hInput; 
    public float vInput;

    
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //// CHARACTER MOVEMENT////
        
        hInput = Input.GetAxisRaw("Horizontal"); 
        vInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(hInput, 0f, vInput).normalized;

        player.Move(direction * speed * Time.deltaTime);


        //// CHARACTER ROTATION////
        
        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }
}
