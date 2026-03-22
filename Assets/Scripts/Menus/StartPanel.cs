using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private Image Cheese3;
    [SerializeField] private Image Cheese2;
    [SerializeField] private Image Cheese1;
    [SerializeField] private Image CheeseYA;
    [SerializeField] private AudioClip startSoundtrack;
    public float waitTime = 1f;
    public static bool isPanelActive;

    public void Awake()
    {
        Cheese2.enabled = false;
        Cheese1.enabled = false;
        CheeseYA.enabled = false;
        isPanelActive = true;
    }

    public void Start()
    {
        StartCoroutine(SwitchImage());
    }
    
    IEnumerator SwitchImage()
    {
        AudioManager.instance.PlaySound(startSoundtrack,1f);
        yield return new WaitForSeconds(waitTime);
        Cheese3.enabled = false;
        Cheese2.enabled = true;
        yield return new WaitForSeconds(waitTime);
        Cheese2.enabled = false;
        Cheese1.enabled = true;
        yield return new WaitForSeconds(waitTime);
        Cheese1.enabled = false;
        CheeseYA.enabled = true;
        yield return new WaitForSeconds(0.5f);
        isPanelActive = false;
        Destroy(this.gameObject);
    }
}
