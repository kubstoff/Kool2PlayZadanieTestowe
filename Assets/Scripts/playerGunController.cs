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

        if (Input.mouseScrollDelta.y != 0)
        {
            current += (int)Input.mouseScrollDelta.y;
            
            if (current > playerWeapon.Length-1)
            {
                current = 0;
            }
            if (current < 0)
            {
                current = playerWeapon.Length-1;
            }
            
            for (int i = 0; i < playerWeapon.Length; i++)
            {
                if (i == current)
                {
                    playerWeapon[i].SetActive(true);
                }
                else
                {
                    playerWeapon[i].SetActive(false);
                }
            }

            
            print(Input.mouseScrollDelta.y);
        }
        

    }
    
    
    
    
    
}
