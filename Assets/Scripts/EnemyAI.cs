using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = System.Random;

public class EnemyAI : EnemyClass

{
    public string checktag;
    public float enemySpeed = 3.3f;
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
        transform.LookAt(new Vector3(follow.transform.position.x, transform.position.y, follow.transform.position.z));

        if (isDead)
        {
            PlayerStats.Instance.enemiesKilled += 1;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthController>().takeDamage(5);
            _collider.enabled = false;
            StartCoroutine(EnableAfter(breakFromAttack));
        }
    }

    private IEnumerator EnableAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _collider.enabled = true;
    }
}