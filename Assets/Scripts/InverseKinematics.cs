using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class InverseKinematics : MonoBehaviour
{

    public int chainLength;
    public GameObject targetObject;
    public GameObject _base;

    public int iterations=10;
    public float delta=0.05f;
    public Vector3 rotationOffset;
    public bool applyTransforms=false;
    
    
    private float[] boneLength;
    private float totalLength;
    private Transform[] Bones;
    private Vector3[] jointPositions;
    private Vector3 worldOffset;
    private Vector3 target;

    private void Awake()
    {
        boneLength = new float[chainLength-1];
        jointPositions = new Vector3[chainLength];
        
        InitIK();
    }

    
    private void LateUpdate()
    {
        if(applyTransforms){
            InitIK();
            applyTransforms = false;
        }
        //worldOffset = base.transform.position;
        CalculateIK();
        ApplyToMesh();
    }

    private void CalculateIK()
    {
        if (Vector3.Distance(targetObject.transform.position, _base.transform.position) > totalLength)
        {
            target = (targetObject.transform.position - _base.transform.position).normalized * totalLength + _base.transform.position;
        }
        else
        {
            target = targetObject.transform.position;
        }
        

        for (int k = 0; k < iterations;k++) {
            
            if(Vector3.Distance( target,jointPositions[jointPositions.Length - 1]) < delta){ break;}

                //forwards
            for (int i = jointPositions.Length - 1; i > 0; i--)
            {


                if (i == jointPositions.Length - 1)
                {

                    jointPositions[i] = target;
                    print("wigwam" + i);
                }
                else
                {
                    print("pingwin" + i);
                    //
                    jointPositions[i] = jointPositions[i + 1] +
                                        (jointPositions[i] - jointPositions[i + 1]).normalized * boneLength[i - 1];
                }
            }

            //backwards
            for (int i = 0; i < jointPositions.Length - 1; i++)
            {


                if (i == 0)
                {
                    jointPositions[i] = _base.transform.position;
                    print("wigwam" + i);
                }
                else
                {
                    print("pingwin" + i);
                    jointPositions[i] = jointPositions[i - 1] +
                                        (jointPositions[i] - jointPositions[i - 1]).normalized * boneLength[i - 1];
                }

            }
        }

    }
    
    private void ApplyToMesh()
    {
        for (int i = 0; i < chainLength; i++)
        {

            Bones[i].position = jointPositions[jointPositions.Length-1 - i];
            

        }

        for (int i = Bones.Length-1; i > 0; i--)
        {
         
            Bones[i].LookAt(Bones[i-1]);
            Bones[i].Rotate(90,0,0 );
          
        }


    }


    //use for debug only
    /*private void OnDrawGizmos()
    {
        CalculateIK();
        //ApplyToMesh();
        for (int i = 0; i < jointPositions.Length-1 ; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(jointPositions[i],0.2f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(jointPositions[i],jointPositions[i+1]);
        }
        
    }*/

    void InitIK()
    {
        Bones = new Transform[chainLength];
        Transform current = this.transform;

        for (int i = 0; i < chainLength; i++)
        {

            Bones[i] = current.transform;
            current = current.transform.parent;

        }

        for (int i = 0; i < jointPositions.Length; i++)
        {
            jointPositions[i] = Bones[i].position;
        }


        for (int i = 0; i < boneLength.Length; i++)
        {

            boneLength[i] = Vector3.Distance(Bones[i].position, Bones[i + 1].position);
            totalLength += boneLength[i];
            print("init bone length " + i + " " + boneLength[i]); 

        }
        print("total length" + totalLength);

    }

}