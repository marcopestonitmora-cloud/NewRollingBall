using UnityEngine;

public class StartSound : MonoBehaviour
{
    [SerializeField] private AudioSource hamsterSoundtrack;
    private bool isPlaying = true;
    void Update()
    {
        if (!StartPanel.isPanelActive && isPlaying)
        {
            hamsterSoundtrack.Play();
            isPlaying = false;
        }
    }
}
