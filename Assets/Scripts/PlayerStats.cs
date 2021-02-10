using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; set; }


    public float playerHealth = 100;
    public float playerMaxHealth = 100;
    public int enemiesKilled = 0;
    public int currentWeaponID;
    public bool isAlive = true;

    public void ResetValues()
    {
        playerHealth = 100;
        enemiesKilled = 0;
        isAlive = true;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}