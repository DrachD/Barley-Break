using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    private static SFXPlayer _instance;
    public static SFXPlayer Instance => _instance; 
    private AudioSource audioSource;
    public float Volume { set => audioSource.volume = value; }
    private void Awake()
    {
        if (_instance != null) { return; }
        _instance = this;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = SFXPrefController.GetSFXVolume();
        DontDestroyOnLoad(this);
    }
    public void ClickSoundActive() => audioSource.Play();
}
