using UnityEngine;
using System.IO;
using System;

public class JsonSystem : MonoBehaviour
{
    public JsonData data = new JsonData();
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

    [Serializable]
    public class JsonData
    {
        public Color backgroundColor;
        public int backgroundId;
        [Space]
        public Color fontColor;
        public int fontId;
    }
}