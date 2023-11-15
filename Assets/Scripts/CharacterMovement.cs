using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 6f;
    public float hInput; 
    public float vInput; 
    public float turnSmootherTime = 0.1f; 
    public float turnSmoothVelocity;
    public Transform playerCamera; 
    public CharacterController  player; // think of this as the motor that controls our player 
    public float velocity;
    private float characterGravity = -9.81f;
    private float gravityScaler = 3.0f;
    private Vector3 direction;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<CharacterController>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ////// BASIC CHARACTER MOVEMENT////////////////
        
        hInput = Input.GetAxisRaw("Horizontal"); 
        vInput = Input.GetAxisRaw("Vertical");

    
       
        /*
        GetAxisRaw is pretty much the same as GetAxis but without the input smoothing
        */
         Vector3 direction = new Vector3(hInput, 0f, vInput).normalized; // this is to mnake sure that when you press 2 buttons you dont move faster.

        /////// CAMEERA AND CHARACTER ROTATION MOVEMENT ///////
       
        if (direction.magnitude >= 0.1f) // this checks if your chartacter is moving in any direction. 
        {
           float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y; // this whole function makes it so that the game can get the angle or rotation it needs on the y axis depening on where your camera is facing
           float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmootherTime);// this helps smooth the rotation turning for our player turning 
           transform.rotation = Quaternion.Euler(0f, angle, 0f);
           
           Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
           player.Move(moveDirection.normalized * speed * Time.deltaTime);

            GravityPhysic(); 
        }
        

       
    }

    void GravityPhysic()
    {
       ////////// GRAVITY PHYSIC/////////////////////////
       
        if (IsGrounded() && velocity < 0.0f)
        {
            velocity = -1.0f;
        }
        else 
        {
            velocity += characterGravity * gravityScaler * Time.deltaTime;
             
        }
        
        direction.y = velocity;
    }

    private bool IsGrounded() => player.isGrounded;


}
