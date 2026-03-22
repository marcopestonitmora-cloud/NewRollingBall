using System;
using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    public PlayerMain Main { get; private set; }
    private Vector3 movement;

    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private bool isMoving = false;
    public bool freeze = false;
    private bool isGrounded = false;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;

    [Header("Audio")]
    [SerializeField] private AudioSource rollingSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private float jumpSoundVolume = 0.8f;

    private void Awake()
    {
        Main = GetComponent<PlayerMain>();
    }

    void Update()
    {
        if (!StartPanel.isPanelActive)
        {
            Freeze();

            // Input del jugador
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

            // Detectar si estamos en el suelo (esfera radio 0.5)
            float sphereRadius = 0.5f; // radio de la esfera
            Vector3 rayOrigin = transform.position;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, sphereRadius + groundCheckDistance, groundLayer);

            // Sonido de movimiento
            if (isGrounded && isMoving)
            {
                if (!rollingSound.isPlaying)
                    rollingSound.Play();
            }
            else
            {
                if (rollingSound.isPlaying)
                    rollingSound.Stop();
            }

            // Saltar solo si estamos en el suelo
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.instance.PlaySound(jumpSound, jumpSoundVolume);
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (freeze) return;

        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Main.rb.AddForce(movement * speed, ForceMode.Force);
    }

    private void Jump()
    {
        Main.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void Freeze()
    {
        if (freeze)
        {
            movement = Vector3.zero;
            Main.rb.linearVelocity = Vector3.zero;
            Main.rb.angularVelocity = Vector3.zero;
        }
    }
}