using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour, WeaponInterface
{
    public GameObject shootCone;
    public float coneLifetime=0.1f;

    public void Shoot(Vector3 target)
    {
        shootCone.SetActive(true);
        StartCoroutine(DisableConeAfterTime(coneLifetime));
    }

    IEnumerator DisableConeAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        shootCone.SetActive(false);
    }
}