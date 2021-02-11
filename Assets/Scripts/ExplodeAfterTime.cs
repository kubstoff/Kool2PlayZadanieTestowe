using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ExplodeAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay=2;
    public GameObject particles;

    private SphereCollider _sphereCollider;
    void Start()
    {
        StartCoroutine(Explode( delay));
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().TakeDamage(300);
        }
      
    
    }

    IEnumerator Explode(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject explosion = Instantiate(particles,transform.position,quaternion.identity);
        _sphereCollider.enabled = true;
        print("boom");
        Destroy(explosion,2 );
        Destroy(this.gameObject,0.1f);
     
    }
}
