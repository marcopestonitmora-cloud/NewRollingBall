using System;
using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    private PlayerMain main;
    private Vector3 movement;
    
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float JumpForce = 7f;
    private bool IsGrounded;
    private float maxRayDistance = 1.1f;
    
    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;
    
    private void Awake()
    {
        main = GetComponent<PlayerMain>();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        //The player’s movement input is modified based on the facing camera direction

        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        movement = (forward * vInput + right * hInput).normalized;

        if (Physics.Raycast(transform.position, Vector3.down, maxRayDistance))
        {
            IsGrounded = true;
        }

        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            IsGrounded = false;
            Jump();
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        main.rb.AddForce(movement * speed, ForceMode.Force);
    }

    private void Jump()
    {
        main.rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }
}
