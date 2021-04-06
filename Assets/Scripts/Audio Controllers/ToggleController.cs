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
    private float defaultVolumeSFX;
    private float defaultVolumeMusic;
    private JsonSystem jsonSystem;

    private void Awake() => toggle = GetComponent<Toggle>();
    private void Start()
    {
        jsonSystem = GameObject.Find("Main Camera").GetComponent<JsonSystem>();
        defaultVolumeSFX = AudioManager.Instance.GetSFXVolume();
        defaultVolumeMusic = AudioManager.Instance.GetMusicVolume();

        if (AudioManager.Instance.OnMusic || AudioManager.Instance.OnSFX)
        {
            isOn = false;
            IsOnOff();
        }
        else
        {
            isOn = true;
            IsOnOff();
        }
    }
    public void IsOnOff()
    {
        if (isOn)
        {
            toggle.targetGraphic.GetComponent<Image>().sprite = spriteOff;
            labelText.text = textOff;

            AudioManager.Instance.SetMusicVolume(0);
            AudioManager.Instance.SetSFXVolume(0);
        }
        else if (!isOn)
        {
            toggle.targetGraphic.GetComponent<Image>().sprite = spriteOn;
            labelText.text = textOn;

            AudioManager.Instance.SetMusicVolume(defaultVolumeMusic);
            AudioManager.Instance.SetSFXVolume(defaultVolumeSFX);
        }

        isOn = !isOn;
    }
}
