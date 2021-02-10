using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public float MaxHealth = 100;
    public float Health = 100;

    public void Start()
    {
        Health = MaxHealth;
        PlayerStats.Instance.playerHealth = Health;
        PlayerStats.Instance.playerMaxHealth = MaxHealth;
    }

    public void takeDamage(float dmg)
    {

        Health -= dmg;

        PlayerStats.Instance.playerHealth = Health;

    }
    
}
