using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    //public
    public float playerSpeed=10;
    public LayerMask mask;
    
    private CharacterController controller;
    private Ray ray;
    private RaycastHit hit;
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        print(movement);
        controller.Move(Time.deltaTime * movement * playerSpeed  ); 
        
        
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         Debug.DrawLine(hit.point, transform.position,Color.red);
         print(hit.point);
         if (Physics.Raycast(ray, out hit,50,mask))
         {
             transform.LookAt(new Vector3(hit.point.x,transform.position.y,hit.point.z));
             //transform.rotation.y = 0;
             //transform.rotation = new Quaternion(transform.rotation)
             //Vector3 newRotation = new Vector3(transform.rotation);


         }
            

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(hit.point,0.5f);
    }
}
