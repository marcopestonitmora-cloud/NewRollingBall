using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private AudioClip playButton;
    [SerializeField] private AudioClip exitButton;

    public void PlayAgain()
    {
        Debug.Log("BOTÓN FUNCIONA");
        AudioManager.instance.PlaySound(playButton,1f);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("BOTÓN FUNCIONA");
        AudioManager.instance.PlaySound(exitButton,1f);
        Debug.Log("Closing the game...");
        Application.Quit();
    }
}
