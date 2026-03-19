using System;
using TMPro;
using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    private PlayerMain main;
    private int _cheeseCounter = 0;
    public int cheeseCounter 
    {
        get => _cheeseCounter;
        private set
        {
            _cheeseCounter = value;

            if (_cheeseCounter > 10)
            {
                _cheeseCounter = 10;   
            }
        }
    }
 
    [SerializeField] private TextMeshProUGUI cheeseTextCounter;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cheeseTextCounter.text = $"{cheeseCounter}/10";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCheese()
    {
        cheeseCounter++;
        cheeseTextCounter.text = $"{cheeseCounter}/10";
    }
}
