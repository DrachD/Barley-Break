using UnityEngine;

public class BackgroundColorPlayer : MonoBehaviour
{
    private static BackgroundColorPlayer _instance;
    public static BackgroundColorPlayer Instance => _instance;
    public Color color;
    public int id;
    public Color Color { get => color; set => color = value; }
    public int Id { get => id; set => id = value; }
    public Color defaultColor = new Color(41, 41, 41, 255);

    private void Awake()
    {
        if (_instance != null) { return; }
        _instance = this;
        
        id = BackgroundColorPrefController.GetIdBackgroundColor();

        if (id == 0)
        { 
            color = defaultColor;
        } else {
            color = BackgroundColorPrefController.GetBackgroundColor();
        }
        DontDestroyOnLoad(this);
    }
}
