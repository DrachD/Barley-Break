using UnityEngine;
using UnityEngine.UI;

public class SFXOptionController : MonoBehaviour
{    
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = AudioManager.Instance.GetSFXVolume();
    }
    private void Update() => AudioManager.Instance.SetSFXVolume(volumeSlider.value);
}
