using System;
using TMPro;
using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cheeseTextCounter;
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
    

    void Start()
    {
        cheeseTextCounter.text = $"{cheeseCounter}/10";
    }
    
    void Update()
    {
        
    }

    public void AddCheese()
    {
        cheeseCounter++;
        cheeseTextCounter.text = $"{cheeseCounter}/10";
    }
}
