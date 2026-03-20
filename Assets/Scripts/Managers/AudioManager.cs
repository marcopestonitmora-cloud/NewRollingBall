using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audioSource;

    //PATRON SINGELTON
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySound(AudioClip sound, float clockBoostVolume)
    {
        audioSource.PlayOneShot(sound);
    }
}
