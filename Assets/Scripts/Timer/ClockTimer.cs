using TMPro;
using UnityEngine;

public class ClockTimer : MonoBehaviour
{
    public float realTime { get; private set;}
    public int clocktimer 
    {
        get => (int)realTime;
        private set
        {
            realTime = value;

            if (realTime < 0)
            {
                realTime = 0;   
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
        realTime += Time.deltaTime;

        if (realTime >= 1f)
        {
            realTime = 0;
            clocktimer--;
            timerText.text = $"{clocktimer}";
        }
    }
}
