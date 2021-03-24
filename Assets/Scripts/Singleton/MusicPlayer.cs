using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;
    public static MusicPlayer Instance => _instance;
    private AudioSource audioSource;
    public float Volume { set => audioSource.volume = value; }
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
}
