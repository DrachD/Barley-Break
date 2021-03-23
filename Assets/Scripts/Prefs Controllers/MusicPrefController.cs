using UnityEngine;

public class MusicPrefController
{
    private const string MASTER_MUSIC_VOLUME = "MASTER_MUSIC_VOLUME";

    public static void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MASTER_MUSIC_VOLUME, value);
    }
    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_MUSIC_VOLUME, 0.8f);
    }
}
