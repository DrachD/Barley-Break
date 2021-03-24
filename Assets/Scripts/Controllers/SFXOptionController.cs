using UnityEngine;
using UnityEngine.UI;

public class SFXOptionController : MonoBehaviour
{
    private SFXPlayer sfxPlayer;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 0.8f;

    private void Start()
    {
        sfxPlayer = FindObjectOfType<SFXPlayer>();
        volumeSlider.value = SFXPrefController.GetSFXVolume();
    }

    private void Update()
    {
        if (sfxPlayer)
        {
            sfxPlayer.Volume = volumeSlider.value;
            SFXPrefController.SetSFXVolume(volumeSlider.value);
        }
    }
}
