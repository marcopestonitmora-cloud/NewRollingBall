using System;
using UnityEngine;

public class CameraMouseLock : MonoBehaviour
{
    public PlayerMain main;

    private void Awake()
    {
        main = FindFirstObjectByType<PlayerMain>();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
        }
        
        if (main.isPlaying)
        { 
            Cursor.visible = false; 
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        { 
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
