using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;

    public float speed;

    public void initialize(Vector3 vec){
    
    direction = vec;
    transform.rotation = Quaternion.LookRotation(vec);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed;


    }
}
