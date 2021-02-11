using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealthController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;

    public void Start()
    {
        health = maxHealth;
        PlayerStats.Instance.playerHealth = health;
        PlayerStats.Instance.playerMaxHealth = maxHealth;
    }

    public void takeDamage(float dmg)
    {
        health -= dmg;

        PlayerStats.Instance.playerHealth = health;

        if (health <= 0)
        {
            GetComponent<CharacterController>().enabled = false;
            PlayerStats.Instance.isAlive = false;
        }
    }
}