using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGunController : MonoBehaviour
{
    public GameObject WeaponSlot;
    public GameObject[] playerWeapon;
    public int current;
    public WeaponInterface weaponinterface;

    private PlayerMovementScript _playerMovementScript;


    private void Start()
    {
        _playerMovementScript = GetComponent<PlayerMovementScript>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerWeapon[current].GetComponent<WeaponInterface>().shoot(_playerMovementScript.mouseTarget );
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
