using System;
using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    public PlayerMain Main {get; private set;}
    private Vector3 movement;
    
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float JumpForce = 7f;
    private bool isGrounded;
    private float maxRayDistance = 1f;
    private bool isMoving = false;
    public bool freeze;
    
    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;
    
    [Header("Audio")]
    [SerializeField] private AudioSource rollingSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private float JumpSoundVolume = 0.8f;
    
    private void Awake()
    {
        Main = GetComponent<PlayerMain>();
    }


    void Start()
    {
        isGrounded = true;
        isMoving = false;
    }

    
    void Update()
    {
        Freeze();
        
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
        if (freeze)
        {
            return;
        }
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Main.rb.AddForce(movement * speed, ForceMode.Force);
    }

    private void Jump()
    {
        Main.rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }
    
    public void Freeze()
    {
        if (freeze)
        {
            movement = Vector3.zero;
            Main.rb.linearVelocity = Vector3.zero;
            Main.rb.angularVelocity = Vector3.zero;
            return;
        }
    }
    
    public void JumpToPoint(Vector3 targetPosition, float trajectoryHeight)
    {  
        Main.rb.linearVelocity = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
    }

    //FORMULA
    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity) 
                                               + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }
}
