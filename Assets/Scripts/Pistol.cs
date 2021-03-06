using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Pistol : MonoBehaviour, WeaponInterface
{
    public GameObject bullet;
    public float bulletSpeed;

    public GameObject shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
    }


    public void Shoot(Vector3 target)
    {
        GameObject b = Instantiate<GameObject>(bullet, shootPoint.transform.position, quaternion.identity);
        b.GetComponent<Bullet>().Initialize(shootPoint.transform.up);
    }
}