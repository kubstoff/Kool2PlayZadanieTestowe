using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class IKMoveTargets : MonoBehaviour
{
    public GameObject[] targets;
    public Vector3 offset;
    public float multiplier=1;
    public GameObject reference;
    
    private GameObject[] startPosition;

    private void Start()
    {
        startPosition = new GameObject[targets.Length];
        
        for (int i = 0; i < targets.Length; i++)
        {
            
            
            //GameObject empty = Instantiate(reference,targets[i].transform.position,quaternion.identity) ;

            startPosition[i] = new GameObject("empty");
            startPosition[i].transform.position = targets[i].transform.position;
            startPosition[i].transform.parent = targets[i].transform.parent;
            
            print(startPosition[i].transform.position);
            
        }
    }

    void Update()
    {

        for (int i = 0; i < targets.Length; i++)
        {
            //print(targets[i]);
            //print(startPosition[i]);
            
            targets[i].transform.position =
                startPosition[i].transform.position + (offset.normalized * multiplier);
        }
        
    }
}
