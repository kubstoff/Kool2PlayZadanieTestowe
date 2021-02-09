using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour,WeaponInterface
{

    public GameObject shootCone;
    // Start is called before the first frame update
  

    public void shoot(Vector3 target)
    {
        shootCone.SetActive(true);
        StartCoroutine( disableConeAfterTime(0.3f));
    }

    // Update is called once per frame
    IEnumerator disableConeAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        shootCone.SetActive(false);
    }
}
