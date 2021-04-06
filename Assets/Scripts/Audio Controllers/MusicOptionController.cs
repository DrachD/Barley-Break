using UnityEngine;
using UnityEngine.UI;

public class MusicOptionController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    private void Start()
    {
        volumeSlider.value = AudioManager.Instance.GetMusicVolume();
    }

    private void Update() => AudioManager.Instance.SetMusicVolume(volumeSlider.value);
}
