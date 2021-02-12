using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using  UnityEditor;

[ExecuteInEditMode]
public class IKManager : MonoBehaviour
{

    public GameObject raycasterBase;
    public Transform moveThis;
    public LayerMask mask;
    public float raycastLength;
    public Transform radiusCenter;
    public float radius;
    public float LerpSeconds;


    private Ray ray;
    private Vector3 hitPosition;
    private Vector3 currentPosition;
    private Vector3 desiredPosition;
    private Vector3 previousPosition;
    private float time=0;
    private float x;
    
    void Awake()
    {
        Cast();
        currentPosition = hitPosition*10;
    }
    
    void Update()
    {
        time += Time.deltaTime;
        Cast();
        if (Vector3.Distance(currentPosition, radiusCenter.position) > radius)
        {
            //print("wigwam");
            currentPosition = hitPosition;
            previousPosition = moveThis.position;
            time = 0;
            
        }

        x = Mathf.Lerp(0,1,time/LerpSeconds);
        moveThis.position = Vector3.Lerp(previousPosition,currentPosition,x) ;


    }
    
    

  
    void Cast()
        {
            if (raycasterBase != null)
            {
                ray.origin = raycasterBase.transform.position;
                ray.direction = raycasterBase.transform.up;
              
            }


            if (Physics.Raycast(ray, out RaycastHit hit, raycastLength, mask.value))
            {
                hitPosition = new Vector3(hit.point.x, hit.point.y,hit.point.z);
                //print("wigwaaam");
            }

            

        }

    void Move()
    {
        
        time += Time.deltaTime;
        moveThis.position = currentPosition; //Vector3.Lerp(currentPosition,desiredPosition,0.5f);
        
        //currentPosition = moveThis.position;

    }
    

    private void OnDrawGizmos()
    {
        Cast();
        Gizmos.color = Color.green;
        Gizmos.DrawRay(ray.origin,ray.direction *raycastLength);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(hitPosition,0.1f);
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(currentPosition,0.1f);
        Gizmos.color = new Color(0.6f,0.96f,0.7f,0.09f);
        Gizmos.DrawSphere(radiusCenter.position,radius);
    }
}
