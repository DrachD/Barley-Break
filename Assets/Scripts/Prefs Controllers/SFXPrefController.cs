using UnityEngine;

public class SFXPrefController
{
    private const string MASTER_SFX_VOLUME = "MASTER_SFX_VOLUME";

    public static void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat(MASTER_SFX_VOLUME, value);
    }
    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_SFX_VOLUME, 0.8f);
    }
}
