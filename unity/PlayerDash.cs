using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    [Tooltip("The point that the player will teleport to when they touch the trigger.")]
    [SerializeField] private Transform checkpoint;
    public CharacterController controller;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            other.TryGetComponent(out PlayerController controller);
            controller.TeleportToPosition(checkpoint.position);
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            Dash();
            Debug.Log("Teleport error");
        }

    }

    public void TeleportToPosition(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }

    private void Dash()
    {
        TeleportToPosition(checkpoint.position);
    }
}
