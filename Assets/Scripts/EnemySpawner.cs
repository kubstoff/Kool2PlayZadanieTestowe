using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnableObject;
    public int spawnMinAtOnce = 0;
    public int spawnMaxAtOnce = 10;
    public int maxAmountOfObjects = 70;

    public float timerCycleSeconds = 5;
    
    public Vector3 min;
    public Vector3 max;
    
    private void Start()
    {
        StartCoroutine (Timer(timerCycleSeconds));    
    }

    private Vector3 randomVec3InRange(Vector3 mini, Vector3 maxi)
    {
        return new Vector3(
            UnityEngine.Random.Range(mini.x,maxi.x),
            UnityEngine.Random.Range(mini.y,maxi.y),
            UnityEngine.Random.Range(mini.z,maxi.z)
        );
    }
    
    private IEnumerator Timer(float seconds)
    {
        while(true)
        {
            if (this.gameObject.transform.childCount <= maxAmountOfObjects)
            {
                for (int i = -spawnMinAtOnce; i < spawnMaxAtOnce; i++)
                {
                    GameObject enemy = Instantiate(spawnableObject, randomVec3InRange(min, max), Quaternion.identity);
                    enemy.transform.SetParent(this.gameObject.transform);
                }
            }

            yield return new WaitForSeconds(seconds);
        }
    }
}
