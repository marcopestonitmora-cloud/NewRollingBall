using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private AudioClip tiktak;
    public PlayerMain main;
    private bool played60 = false;
    private bool played40 = false;
    private bool played20 = false;
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

    void Awake()
    {
        main = FindObjectOfType<PlayerMain>();
    }


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

        if (clocktimer == 60 && !played60)
        {
            played60 = true;
            AudioManager.instance.PlaySound(tiktak,1f);
        }
        else if (clocktimer == 40 && !played40)
        {
            played40 = true;
            AudioManager.instance.PlaySound(tiktak,1f);
        }
        else if (clocktimer == 20 && !played20)
        {
            played20 = true;
            AudioManager.instance.PlaySound(tiktak,1f);
        }

        if (clocktimer == 0)
        {
            if (main != null)
            {
                main.isPlaying = false;
            }
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }
    }

    public void MoreTime()
    {
        clocktimer += 20;
    }
}
