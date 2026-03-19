using System;
using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    private PlayerMain main;
    [SerializeField] private Cheese Cheese;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Cheese>() != null)
        {
            Console.WriteLine($"Colected cheese: {Cheese.cheeseCounter}");
        }
    }
}
