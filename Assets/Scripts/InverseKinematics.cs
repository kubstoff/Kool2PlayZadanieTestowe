using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InverseKinematics : MonoBehaviour
{

    public int chainLength;
    public Transform Target;
    public GameObject Base;

    public int iterations;
    public float delta;

    private float[] boneLength;
    private float totalLength;
    private Transform[] Bones;
    private Vector3[] jointPositions;
    private Vector3 worldOffset;

    private void Awake()
    {
        boneLength = new float[chainLength];
        InitIK();
    }

    private void Update()
    {
        worldOffset = base.transform.position;

        if (Vector3.Distance(Target.transform.localPosition, Base.transform.localPosition) > totalLength)
        {

        }

        for (int i = 0; i < chainLength-1 ;i++)
        {


            if (i == 0)
            {
                Bones[i].position = Target.position + Base.transform.position;
            }
            else
            {
                Bones[i].position = (Bones[i - 1].position +  - Bones[i].position).normalized * boneLength[i-1];
            }


        }


    }


    void InitIK()
    {
        Bones = new Transform[chainLength];
        Transform current = this.transform;

        for (int i = 0; i < chainLength; i++)
        {

            Bones[i] = current.transform;
            current = current.transform.parent;

        }

        for (int i = 0; i < chainLength; i++)
        {
            print( Bones[i]);
        }


        for (int i = 0; i < chainLength-1; i++)
        {

            boneLength[i] = Vector3.Distance(Bones[i].position, Bones[i + 1].position);
            totalLength += boneLength[i];
            print(boneLength[i]); 

        }

    }

}