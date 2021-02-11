using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject follow;
    
    private Vector3 offset;


    private void Awake()
    {
       
    }

    private void Start()
    {
        transform.position = new Vector3(follow.transform.position.x,transform.position.y, transform.position.z); 

        offset = follow.transform.position - transform.position;
        transform.LookAt(follow.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = follow.transform.position - offset;
        
    }
}
