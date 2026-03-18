using System;
using UnityEngine;

public class PlayerMovementSystem : MonoBehaviour
{
    private PlayerMain main;
    private Vector3 movement;
    
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    
    private void Awake()
    {
        main = GetComponent<PlayerMain>();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        
        movement = new Vector3(hInput, 0, vInput).normalized;
        PlayerMovement();
    }

    public void PlayerMovement() //Add Forces to move the player
    {
        main.rb.AddForce(movement * speed, ForceMode.Force);
    }
}
