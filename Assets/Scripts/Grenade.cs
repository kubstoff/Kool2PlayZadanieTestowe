using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour, WeaponInterface
{
    public GameObject throwGrenade;
    public float grenadeFlightTime = 1;

    public void shoot(Vector3 target)
    {
        
        Vector3 throwVector = new Vector3(
            target.x - transform.position.x/grenadeFlightTime,
            Physics.gravity.y * (- 1) * (grenadeFlightTime* grenadeFlightTime)/2  ,
            target.z - transform.position.z/grenadeFlightTime
        );
        //throwVector.Normalize();
        GameObject createdGrenade = Instantiate(throwGrenade, transform.position, transform.rotation);

        Rigidbody rb = createdGrenade.GetComponent<Rigidbody>();
            //rb.AddForce(throwVector * rb.mass);
            rb.velocity = throwVector;
    }

    
}