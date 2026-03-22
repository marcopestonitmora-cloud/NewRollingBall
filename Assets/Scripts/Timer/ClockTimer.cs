using TMPro;
using UnityEngine;

public class ClockTimer : MonoBehaviour
{
    public float realTime { get; private set;}
    private int _realTime = 240;
    public int clocktimer 
    {
        get => _realTime;
        private set
        {
            _realTime = value;

            if (_realTime < 0)
            {
                _realTime = 0;   
            }
        }
    }
    
    [SerializeField] private TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = $"{clocktimer}";
    }

    // Update is called once per frame
    void Update()
    {
        Clocktimer();
    }

    public void Clocktimer()
    {
        if (!StartPanel.isPanelActive)
        {
            
            realTime += Time.deltaTime;

            if (realTime >= 1f)
            {
                realTime = 0;
                clocktimer--;
                timerText.text = $"{clocktimer}";
            }   
        }
    }

    public void MoreTime()
    {
        clocktimer += 20;
    }
}
