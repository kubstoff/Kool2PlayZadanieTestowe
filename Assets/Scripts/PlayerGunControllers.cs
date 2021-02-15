using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerGunControllers : MonoBehaviour
{
    public GameObject weaponSlot;
    public GameObject[] playerWeapon;
    public int current;

    
    //private
    private PlayerMovementScript _playerMovementScript;


    private void Start()
    {
        _playerMovementScript = GetComponent<PlayerMovementScript>();
    }

    void Update()
    {
        weaponSlot.transform.LookAt(_playerMovementScript.mouseTarget);
        
        if (PlayerStats.Instance.isAlive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerWeapon[current].GetComponent<WeaponInterface>().Shoot(_playerMovementScript.mouseTarget);
            }

            if (Input.mouseScrollDelta.y != 0)
            {
                current += (int) Input.mouseScrollDelta.y;

                if (current > playerWeapon.Length - 1)
                {
                    current = 0;
                }

                if (current < 0)
                {
                    current = playerWeapon.Length - 1;
                }

                PlayerStats.Instance.currentWeaponID = current;
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
            }
        }
        
    }
}