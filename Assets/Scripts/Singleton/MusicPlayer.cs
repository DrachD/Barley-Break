using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;
    public static MusicPlayer Instance => _instance;
    private AudioSource audioSource;
    private void Awake()
    {
        if (_instance != null) { return; }
        
        _instance = this;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.loop = true;
        audioSource.volume = MusicPrefController.GetMusicVolume();

        DontDestroyOnLoad(this);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
