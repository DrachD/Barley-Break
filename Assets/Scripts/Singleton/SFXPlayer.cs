using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private static SFXPlayer _instance;
    public static SFXPlayer Instance => _instance; 
    private AudioSource audioSource;
    private void Awake()
    {
        if (_instance != null) { return; }
        _instance = this;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SFXPrefController.GetSFXVolume();
        DontDestroyOnLoad(this);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void ClickSoundActive()
    {
        audioSource.Play();
    }
}
