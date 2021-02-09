using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour, WeaponInterface
{
    public GameObject throwGrenade;
    

    public void shoot(Vector3 target)
    {
        
        Vector3 throwVector = new Vector3(
            target.x - transform.position.x,
            Physics.gravity.y * (- 1) /2  ,
            target.z - transform.position.z
        );
        //throwVector.Normalize();
        GameObject createdGrenade = Instantiate(throwGrenade, transform.position, transform.rotation);

        Rigidbody rb = createdGrenade.GetComponent<Rigidbody>();
            
            rb.velocity = throwVector;
    }

    
}