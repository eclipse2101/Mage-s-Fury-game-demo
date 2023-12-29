using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
     [SerializeField] private Transform focusPoint; // serializefields make a variable private while making it acciseable in the unity editor without making it public
     private float offset; 
     private Vector2 input; 

     [SerializeField] private MouseSensitivity MSenitivity;
     [SerializeField] private CameraAngle cameraAngle;  
     private CameraRotation cameraRotation; 
     
     void Awake()
    {
        offset = Vector3.Distance(transform.position, focusPoint.position);
    }

    void Update()
    {
        cameraRotation.Yaw += input.x * MSenitivity.horizontalInput * Time.deltaTime; 
        cameraRotation.Pitch += input.y * MSenitivity.verticalInput * Time.deltaTime;
        cameraRotation.Pitch = Mathf.Clamp(cameraRotation.Pitch, cameraAngle.min, cameraAngle.max);
        cameraRotation.Yaw = Mathf.Clamp(cameraRotation.Yaw, cameraAngle.min, cameraAngle.max);
    }
    
    void LateUpdate()
    {
         transform.eulerAngles = new Vector3 (cameraRotation.Pitch, cameraRotation.Yaw, 0.0f);
         transform.position = focusPoint.position - transform.forward * offset;
         // this will make it so that the last piroity of the game is to fix the camreas position
    }

    public void Look(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
}

 
 [Serializable]
 public struct MouseSensitivity
 {
   public float horizontalInput; 
   public float verticalInput;   
 }

 public struct CameraRotation
 {
    public float Pitch;
    public float Yaw; 
 }

 public struct CameraAngle
 {
    public float min;
    public float max; 
 }
