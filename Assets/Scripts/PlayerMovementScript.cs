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

    private CharacterController controller;
    private Ray ray;
    private RaycastHit hit;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (PlayerStats.Instance.isAlive == true)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            controller.Move(Time.deltaTime * playerSpeed * movement);

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50, mask.value))
            {
                mouseTarget = new Vector3(hit.point.x, transform.position.y, hit.point.z);
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