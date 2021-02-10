using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyInterface
{
    public float Health { get; set; }
    public float Walkspeed { get; set; }

    public bool isDead { get; set; }


    void ApplyDamage(float dmg);


}
