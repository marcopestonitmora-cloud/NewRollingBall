using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public Rigidbody rb {get; private set;}
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
}
