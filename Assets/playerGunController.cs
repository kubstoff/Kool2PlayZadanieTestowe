using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGunController : MonoBehaviour
{
    public GameObject WeaponSlot;
    public GameObject[] playerWeapon;
    public int current;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerWeapon[current].GetComponent<WeaponInterface>().shoot(new Vector3(0f,0f,0f));
        }


    }
}
