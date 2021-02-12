using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject follow;
    
    private Vector3 offset;
    

    private void Start()
    {
        transform.position = new Vector3(follow.transform.position.x,transform.position.y, transform.position.z); 

        offset = follow.transform.position - transform.position;
    
    }
    
    void Update()
    {
        
        transform.position = follow.transform.position - offset;
        
    }
}
