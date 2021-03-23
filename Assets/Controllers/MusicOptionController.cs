using UnityEngine;
using UnityEngine.UI;

public class MusicOptionController : MonoBehaviour
{
    private MusicPlayer musicPlayer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 0.8f;

    private void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        volumeSlider.value = MusicPrefController.GetMusicVolume();
    }

    private void Update()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
            MusicPrefController.SetMusicVolume(volumeSlider.value);
        }
    }
}
