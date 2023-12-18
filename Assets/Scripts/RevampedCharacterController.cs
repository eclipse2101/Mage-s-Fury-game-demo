using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))] // this makes sure your character has a character controller before starting the game

public class RevampedCharacterController : MonoBehaviour
{
    public CharacterController player; // think of this as the motor that controls our player 
    public float speed;
    private Vector3 direction; 
    private Vector2 Input; 
    public float turnSmoothVelocity;
    public float turnSmootherTime = 0.1f; 
    float characterGravity = -9.81f;
    public float gravityScaler = 3.0f;
    public float velocity;
    public float JumpPower;
  

    
    
    void Awake()
    {
        player = GetComponent<CharacterController>();
    }
    
    
    

    // Update is called once per frame
    void Update()
    {
      
      GravityFunction();
      RotationFunction();
      MovementFunction();
        
    } 
    
    //// Applying Gravity ///////
    private void GravityFunction()
    {
         if (IsOnGround() && velocity < 0.0f)// it checks if the player is grounded or not
        {
            velocity = -1.0f;
          
        }
        else
        {
            velocity += characterGravity * gravityScaler * Time.deltaTime;
        }
         
         direction.y = velocity;
    }
    
    //// CHARACTER ROTATION////
    private void RotationFunction()
    {
         if(Input.sqrMagnitude == 0) return; // this will prevent your character from looking straight forward
        
        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmootherTime);// this helps smooth the rotation turning for our player turning 
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    } 

    //// CHARACTER MOVEMENT////
    private void MovementFunction()
    {
        /// the line of code that makes the character actual useable//

         player.Move(direction * speed * Time.deltaTime);
    }
    
    
    public void Movement(InputAction.CallbackContext context)
    {
       Input = context.ReadValue<Vector2>();
       direction = new Vector3(Input.x, 0f, Input.y).normalized;
    }

    public void Jumping (InputAction.CallbackContext context)
    {
        if(!context.started ) return; // this will return nothing if the spacebar was not pressed down 
        if (!IsOnGround()) return; // if the character is not on the ground it will return nothing 

        velocity += JumpPower;
    }

    private bool IsOnGround() => player.isGrounded;

}

