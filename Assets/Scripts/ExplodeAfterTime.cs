using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ExplodeAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay=2;
    public GameObject particles;
    void Start()
    {
        StartCoroutine(Explode( delay));
    }

    IEnumerator Explode(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject explosion = Instantiate(particles,transform.position,quaternion.identity);
        GetComponent<SphereCollider>().enabled = true;
        print("boom");
        Destroy(this.gameObject,0.1f);
        
        Destroy(explosion,2 );
    }
}
