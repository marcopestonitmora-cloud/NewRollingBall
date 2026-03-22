using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    [SerializeField]public Image vida1;
    [SerializeField]public Image vida2;
    [SerializeField]public Image vida3;
    public PlayerMain main;
    
    private int livesCounter = 3;
    public int LivesCounter
    {
        get => livesCounter;
        private set
        {
            if (value < 0)
                livesCounter = 0;
            else if (value > 3)
                livesCounter = 3;
            else
                livesCounter = value;
        }
    }

    private void Awake()
    {
        main = FindObjectOfType<PlayerMain>();
    }

    
    public void LoseLives()
    {
        livesCounter--;
        if (livesCounter == 2)
        {
            vida3.enabled = false;
        }
        else if (livesCounter == 1)
        {
            vida2.enabled = false;
        }
        else if (livesCounter == 0)
        {
            vida1.enabled = false;

            if (main != null)
            {
                 main.isPlaying = false;
            }
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene(2);
        }
    }
}
