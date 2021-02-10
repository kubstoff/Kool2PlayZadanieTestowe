using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyAI : EnemyClass

{
    //public GameObject follow;
    //public string followThisName;
    public string checktag;
    public float enemySpeed = 3.3f;
    
    private GameObject follow;
    private CharacterController enemyController;
    private Vector3 direction;

    
    private void Start()
    {
        enemyController = GetComponent<CharacterController>();
        follow = GameObject.FindWithTag(checktag);

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
}
