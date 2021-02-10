using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = System.Random;

public class EnemyAI : EnemyClass

{
    //public GameObject follow;
    //public string followThisName;
    public string checktag;
    public float enemySpeed = 3.3f;
    public float damage = 5;
    public float breakFromAttack = 1;
    
    private GameObject follow;
    private CharacterController enemyController;
    private Vector3 direction;
    private BoxCollider _collider;

    
    private void Start()
    {
        enemyController = GetComponent<CharacterController>();
        follow = GameObject.FindWithTag(checktag);
        _collider = GetComponent<BoxCollider>();


    }

    private void Update()
    {
        direction = (follow.transform.position - transform.position).normalized;
        enemyController.Move(Time.deltaTime * enemySpeed * direction);
        transform.LookAt(new Vector3(follow.transform.position.x,transform.position.y,follow.transform.position.z));

        if (isDead)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           other.GetComponent<PlayerHealthController>().takeDamage(5);
           _collider.enabled = false;
           StartCoroutine(enableAfter(breakFromAttack));
        }
    }

    private IEnumerator enableAfter(float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        _collider.enabled = true;
    }

    private void OnDestroy()
    {
        PlayerStats.Instance.enemiesKilled += 1;
    }
}
