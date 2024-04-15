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
    public int timer;
    public int hitCount = 0; 
    public int cooldown; 
    public GameObject hand1;
    public GameObject hand2;

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
      AnimationChecker();
      
      
      
    } 
    
    //// Applying Gravity ///////
    private void GravityFunction()
    {
         if (IsOnGround() && velocity < 0.0f)// it checks if the player is grounded or not
        {
            velocity = -1.0f;
           animationRunner.SetBool("is falling", false);
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
        Debug.Log("player has jumped");
        velocity += JumpPower;
      
    }

    public void Attacking() 
    {
      if (!IsOnGround()) return;  
      
      hitCount++;
      
      /*
      if(hitCount == 1)
       {
        animationRunner.SetInteger("punches", hitCount);
       }
       
       if(hitCount == 2)
       {
        animationRunner.SetInteger("punches", hitCount);
       }
       
       if(hitCount == 3)
       {
        animationRunner.SetInteger("punches", 3);
       }
       */


       if(hitCount > 3)
       {
        hitCount = 0;
       }

       animationRunner.SetInteger("punches", hitCount);
      //Debug.Log("player clicked the attack button");
    }
    
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hand1.transform.position, 0.75f);
    }
    
    void AnimationChecker()
    {
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

    }

    private bool IsOnGround() => player.isGrounded;

}

