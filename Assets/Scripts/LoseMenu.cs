using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private AudioClip playButton;
    [SerializeField] private AudioClip exitButton;

    public void PlayAgain()
    {
        AudioManager.instance.PlaySound(playButton,1f);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        AudioManager.instance.PlaySound(exitButton,1f);
        SceneManager.LoadScene(0);
    }
}
