using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    
   
    [SerializeField] private float defaultMoveSpeed = 3.5f;
    [SerializeField] private float gravity = 30f;
    
    
    private Rigidbody rb;
    private Vector3 motionStep;
    private float currentSpeed = 0f;
    private CharacterController controller;
    private Camera mainCamera;
    private Vector3 moveVelocity;
    private Vector3 target;
    private float velocity = 0f;



    public bool CanMove { get; set; } = true;

    private void Awake()
    {
        TryGetComponent(out controller);
    }



    private void Start()
    {
        currentSpeed = defaultMoveSpeed;

        mainCamera = FindObjectOfType<Camera>();
    }


    private void FixedUpdate()
    {
        if (CanMove == true)
        {
            if (controller.isGrounded == true)
            {
                velocity = -gravity * Time.deltaTime;
            }
            else
            {
                velocity -= gravity * Time.deltaTime;
            }
        }
    }

    void Update()
    {
        if (CanMove == true)
        ApplyMovement();

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void ApplyMovement()
    {
        motionStep = Vector3.zero;
        motionStep += transform.forward * Input.GetAxisRaw("Vertical");
        motionStep += transform.right * Input.GetAxisRaw("Horizontal");
        motionStep = currentSpeed * motionStep.normalized;
        motionStep.y += velocity;
        controller.Move(motionStep * Time.deltaTime);
     
    }


    public void TeleportToPosition(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }

    

}
