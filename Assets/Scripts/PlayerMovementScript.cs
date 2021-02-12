using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovementScript : MonoBehaviour
{
    //public
    public float playerSpeed = 10;
    public LayerMask mask;
    public Vector3 mouseTarget;

    private CharacterController _controller;
    private Ray _ray;
    private RaycastHit _hit;
    private IKMoveTargets moveRaycasters;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        moveRaycasters= GetComponent<IKMoveTargets>();
    }

    void Update()
    {
        if (PlayerStats.Instance.isAlive == true)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            _controller.Move(Time.deltaTime * playerSpeed * movement);

            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 50, mask.value))
            {
                mouseTarget = new Vector3(_hit.point.x, transform.position.y, _hit.point.z);
                transform.LookAt(mouseTarget);
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                PlayerStats.Instance.ResetValues();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}