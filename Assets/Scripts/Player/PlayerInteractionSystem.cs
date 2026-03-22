using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    void Awake()
    {
        main = FindObjectOfType<PlayerMain>();
    }


    void Start()
    {
        cheeseTextCounter.text = $"{cheeseCounter}/10";
    }

    public void AddCheese()
    {
        cheeseCounter++;
        cheeseTextCounter.text = $"{cheeseCounter}/10";
        if (cheeseCounter == 10)
        {
            if (main != null)
            {
                main.isPlaying = false;
            }
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            SceneManager.LoadScene(3);
        }
    }
}
