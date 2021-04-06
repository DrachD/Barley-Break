using UnityEngine;
using System.IO;
using System;

[Serializable]
public class JsonData
{
    public Color backgroundColor;
    public int backgroundId;
    [Space]
    public Color fontColor;
    public int fontId;
    [Space]
    public float volumeSFX;
    public float volumeMusic;
}

public class JsonSystem : MonoBehaviour
{
    [SerializeField] JsonData data = new JsonData();
    public JsonData JsonData => data;
    private string path;
    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        path = Path.Combine(Application.persistentDataPath, "Save.json"); 
#else
        path = Path.Combine(Application.dataPath, "Save.json");
#endif
        LoadData();
    }
        
    public void SaveData() => File.WriteAllText(path, JsonUtility.ToJson(data));

    private void LoadData() => data = JsonUtility.FromJson<JsonData>(File.ReadAllText(path));

    private void OnDestroy()
    {
        JsonData.volumeMusic = AudioManager.Instance.GetMusicVolume();
        JsonData.volumeSFX = AudioManager.Instance.GetSFXVolume();
        SaveData();
    }

}