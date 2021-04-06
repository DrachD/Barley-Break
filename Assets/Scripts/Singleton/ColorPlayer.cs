using UnityEngine;

public class ColorPlayer : MonoBehaviour
{
    #region Static Instance
    private static ColorPlayer instance;
    public static ColorPlayer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ColorPlayer>();
                if (instance == null)
                {
                    Debug.Log("spawned");
                    instance = new GameObject("Spawned ColorPlayer", typeof(ColorPlayer)).GetComponent<ColorPlayer>();
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
    [HideInInspector]
    public Color BackgroundColor;

    [HideInInspector]
    public int BackgroundId;

    [HideInInspector]
    public Color FontColor;

    [HideInInspector]
    public int FontId;
    
    private void Awake()
    {
        if (instance != null) return;

        JsonData json = GameObject.Find("Main Camera").GetComponent<JsonSystem>().JsonData;

        BackgroundColor = json.backgroundColor;
        BackgroundId = json.backgroundId;
        FontColor = json.fontColor;
        FontId = json.fontId;

        DontDestroyOnLoad(this);
    }
}
