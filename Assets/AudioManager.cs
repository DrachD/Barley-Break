using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Static Instance
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    Debug.Log("spawned");
                    instance = new GameObject("Spawned AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }

            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    #endregion

    #region Audio
    [SerializeField] private AudioClip audio_clickSFX;
    public AudioClip AUDIO_clickSFX => audio_clickSFX;
    [SerializeField] private AudioClip audio_music;
    public AudioClip AUDIO_music => audio_music;

    #endregion

    #region Boolean
    [HideInInspector]
    public bool OnMusic { get; private set; }
    [HideInInspector]
    public bool OnSFX { get; private set; }
    #endregion

    #region Fields
    private AudioSource musicSource;
    private AudioSource sfxSource;

    #endregion

    private void Awake()
    {
        if (instance != null) return;

        DontDestroyOnLoad(this);

        JsonData json = FindObjectOfType<JsonSystem>().JsonData;
        musicSource = gameObject.AddComponent<AudioSource>();
        SetMusicVolume(json.volumeMusic);

        sfxSource = gameObject.AddComponent<AudioSource>();
        SetSFXVolume(json.volumeSFX);

        musicSource.clip = audio_music;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.volume = musicSource.volume;
        musicSource.Play();
    }
    #region Play SFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }
    #endregion

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;

        OnMusic = (volume <= 0) ? false : true;
    }
    
    public float GetMusicVolume() => musicSource.volume;

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;

        OnSFX = (volume <= 0) ? false : true;
    }

    public float GetSFXVolume() => sfxSource.volume;
}
