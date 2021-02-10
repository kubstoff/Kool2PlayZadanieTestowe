using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyClass : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public bool isDead = false;
    public Slider slider;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            isDead = true;
        }

        if (slider != null)
        {
            slider.value = health / maxHealth;
        }
    }
}