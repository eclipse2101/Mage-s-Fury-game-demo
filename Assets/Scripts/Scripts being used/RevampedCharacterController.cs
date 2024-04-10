using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))] // this makes sure your character has a character controller before starting the game

public class RevampedCharacterController : MonoBehaviour
{
    public CharacterController player; // think of this as the motor that controls our player 
    public float speed;
    public Vector3 direction; 
    private Vector2 Input; 
    public float rotationSpeed = 500f; 
    float characterGravity = -9.81f;
    public float gravityScaler = 3.0f;
    public float velocity = -1.0f;
    public float JumpPower;
    private Camera mainCamera; 
    Animator animationRunner;

    void Start()
    {
        animationRunner = GetComponent<Animator>();
    }
    
    void Awake()
    {
        player = GetComponent<CharacterController>();
        mainCamera = Camera.main; 
    }
    
    
    

    // Update is called once per frame
    void Update()
    {
      
      RotationFunction();
      GravityFunction();
      MovementFunction();
      
      // animation statments///
      if (direction.x != 0f || direction.z != 0f)
      {
        animationRunner.SetBool("is running", true);
        animationRunner.SetBool("jumped", false);
        animationRunner.SetBool("is falling", false);
      }
      else
      {
        animationRunner.SetBool("is running", false);
      }

      if (velocity > -1.0f)
      {
        animationRunner.SetBool("jumped", true);
        animationRunner.SetBool("is running", false);
      }
      else if( velocity < -1.0f)
      {
        animationRunner.SetBool("jumped", false);
        animationRunner.SetBool("is running", false);
        animationRunner.SetBool("is falling", true);
      }
      /*
       if (velocity = -1)
      {
        animationRunner.SetBool("jumped", false);
        animationRunner.SetBool("is running", false);
        animationRunner.SetBool("is falling", false);
      }
      */
    } 
    
    //// Applying Gravity ///////
    private void GravityFunction()
    {
         if (IsOnGround() && velocity < 0.0f)// it checks if the player is grounded or not
        {
            velocity = -1.0f;
          //animationRunner.SetBool("jumped", false);
          //animationRunner.SetBool("is falling", true);
        }
        else
        {
            velocity += characterGravity * gravityScaler * Time.deltaTime;
            //animationRunner.SetBool("is falling", false);
        }
         
         direction.y = velocity;
       
    }
    
    //// CHARACTER ROTATION////
    private void RotationFunction()
    {
         if(Input.sqrMagnitude == 0) return; // this will prevent your character from looking straight forward
        
         direction = Quaternion.Euler(0.0f, mainCamera.transform.eulerAngles.y, 0.0f) * new Vector3(Input.x, 0.0f, Input.y);
         var targetRotation = Quaternion.LookRotation(direction, Vector3.up); 

         transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
         
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
        //animationRunner.SetBool("jumped", true);
      
    }

    private bool IsOnGround() => player.isGrounded;

}

