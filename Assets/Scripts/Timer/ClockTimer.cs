using TMPro;
using UnityEngine;

public class ClockTimer : MonoBehaviour
{
    public float timer { get; private set; } = 240f;
    [SerializeField] private TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerText.text = $"{timerText}";
    }

    // Update is called once per frame
    void Update()
    {
        Clocktimer();
    }

    public void Clocktimer()
    {
        timer -= Time.deltaTime;
        timerText.text = $"{timer}";
    }
}
