using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public Rigidbody rb {get; private set;}
    public bool isPlaying { get; set; } = true;
    
    private void Awake()
    {
        isPlaying = true;
        rb = GetComponent<Rigidbody>();
    }
}
