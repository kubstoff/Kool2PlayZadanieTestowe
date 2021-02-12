using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class InverseKinematics : MonoBehaviour
{
    //public
    public int chainLength = 3;
    public Transform target;
    public Transform pole;

    public int iterations;
    public float delta;

    
    //private
    private float[] BonesLength;
    private float completeLength;
    private Transform[] Bones;
    private Vector3[] Positions;

    private void Awake()
    {
        Init();
    }

    private void LateUpdate()
    {
        SolveIK();
    }

     void SolveIK()
     {
         if ( target == null) {return;}
         

         //getposition
         for (int i = 0; i < Bones.Length; i++)
         {
             Positions[i] = Bones[i].position;
         }

         //check if out of range
         if ((target.position - Bones[0].position).sqrMagnitude  > completeLength*completeLength)
         {
             Vector3 direction = (target.position - Positions[0]).normalized;

             for (int i = 1; i < Positions.Length; i++)
             {
                 Positions[i] = Positions[i - 1] + direction * BonesLength[i - 1];
             }
  
         }
         else
         {
             for (int iteration = 0; iteration < iterations; iteration++)
             {
                 //back
                 for (int i = Positions.Length-1; i >0; i--)
                 {
                     if (i == Positions.Length - 1)
                     {
                         Positions[i] = target.position;
                     }
                     else
                     {
                         Positions[i] = Positions[i + 1] +
                                        (Positions[i] - Positions[i + 1]).normalized * BonesLength[i];
                     }
                     
                 }
                 
                 //forth
                 for (int i = 1; i < Positions.Length; i++)
                 {
                     Positions[i] = Positions[i - 1] +
                                    (Positions[i] - Positions[i - 1]).normalized * BonesLength[i - 1];
                 }

                 if ((Positions[Positions.Length - 1] - target.position).magnitude < delta) {break;}


             }
         }

         //pull
         if (pole != null)
         {
             for (int i = 1; i < Positions.Length - 1; i++)
             {
                 
                 Plane plane = new Plane(Positions[i + 1] - Positions[i - 1], Positions[i - 1]);
                 
                 Vector3 projectedPole = plane.ClosestPointOnPlane(pole.position);
                 
                 Vector3 projectedBone = plane.ClosestPointOnPlane(Positions[i]);
                 
                 float angle = Vector3.SignedAngle(projectedBone - Positions[i - 1], projectedPole - Positions[i - 1],
                     plane.normal);
                 
                 Positions[i] = Quaternion.AngleAxis(angle, plane.normal) *
                                (Positions[i] - Positions[i - 1]) + Positions[i - 1];

             }
         }
         
        
         
         //set rotation
         for (int i = 0; i < Bones.Length-1; i++)
         {
         
             Bones[i].LookAt(Bones[i+1]);
         }
         
         ///set position
         for (int i = 0; i < Positions.Length; i++)
         {
             Bones[i].position = Positions[i];
         }
         
         
    }

     void Init()
     {
         Bones = new Transform[chainLength + 1];
         Positions = new Vector3[chainLength + 1];
         BonesLength = new float[chainLength];
         completeLength = 0;

         var current = transform;
         for (var i = Bones.Length - 1; i >= 0; i--)
         {

             Bones[i] = current;

             if (i == Bones.Length - 1)
             {

             }
             else
             {
                 BonesLength[i] = (Bones[i + 1].position - current.position).magnitude;
                 completeLength += BonesLength[i];


                 current = current.parent;

             }

         }
     }

     //uncomment only for debug
     /*
     private void OnDrawGizmos()
    {
        //Init(); 
        //SolveIK(); //debug
        
        for (int i = 0; i < Positions.Length; i++)
        {
            Gizmos.color=Color.green;
            Gizmos.DrawSphere(Positions[i],0.2f);
            
        }
        
        for (int i = 0; i < Positions.Length-1; i++)
        {
            Gizmos.color=Color.red;
            Gizmos.DrawLine(Positions[i],Positions[i+1]);           
        } 
    }
    */
}