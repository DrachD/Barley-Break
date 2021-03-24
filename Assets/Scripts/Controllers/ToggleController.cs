using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    private Toggle toggle;
    private bool isOn;
    [SerializeField] Text labelText;
    [SerializeField] Sprite spriteOn;
    [SerializeField] Sprite spriteOff;
    [SerializeField] string textOn;
    [SerializeField] string textOff;
    private float volumeMusicValue;
    private float volumeSFXValue;
    private MusicPlayer musicPlayer;
    private SFXPlayer sfxPlayer;

    private void Awake() => toggle = GetComponent<Toggle>();
    private void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        sfxPlayer = FindObjectOfType<SFXPlayer>();
        volumeMusicValue = MusicPrefController.GetMusicVolume();
        volumeSFXValue = SFXPrefController.GetSFXVolume();

        isOn = true;
    }
    public void IsOnOff()
    {
        if (isOn)
        {
            toggle.targetGraphic.GetComponent<Image>().sprite = spriteOff;
            labelText.text = textOff;
            musicPlayer.Volume = 0;
            sfxPlayer.Volume = 0;
        }
        else if (!isOn)
        {
            toggle.targetGraphic.GetComponent<Image>().sprite = spriteOn;
            labelText.text = textOn;
            musicPlayer.Volume = volumeMusicValue;
            sfxPlayer.Volume = volumeSFXValue;
        }

        isOn = !isOn;
    }


}
