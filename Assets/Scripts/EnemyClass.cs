using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    private float health;
    private bool isDead;
    
    public void dealDamage(float dmg){

        health -= dmg;
        if (health <= 0)
        {
            isDead = true;
        }

    }


}
