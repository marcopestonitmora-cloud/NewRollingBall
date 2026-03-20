using System;
using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    private PlayerMain main;
    private Vector3 movement;
    
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float JumpForce = 7f;
    private bool isGrounded;
    private float maxRayDistance = 1f;
    private bool isMoving = false;
    
    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;
    
    [Header("Audio")]
    [SerializeField] private AudioSource rollingSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private float JumpSoundVolume = 0.8f;
    
    private void Awake()
    {
        main = GetComponent<PlayerMain>();
    }


    void Start()
    {
        isGrounded = true;
        isMoving = false;
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
        
        isMoving = movement.magnitude > 0.1f;
        
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxRayDistance);
        
        if (isGrounded && isMoving)
        {
            if (!rollingSound.isPlaying)
            {
                 rollingSound.Play();
            }

        }
        else
        {
            if (rollingSound.isPlaying)
            {
                rollingSound.Stop();
            }
        }
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            AudioManager.instance.PlaySound(jumpSound,JumpSoundVolume);
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
