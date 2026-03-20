using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    [SerializeField]public Image vida1;
    [SerializeField]public Image vida2;
    [SerializeField]public Image vida3;
    
    private int livesCounter = 3;
    public int _livesCounter 
    {
        get => livesCounter;
        private set
        {
            if (livesCounter <= 0)
            {
                livesCounter = 0;
            }
        }
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
        }
    }
}
