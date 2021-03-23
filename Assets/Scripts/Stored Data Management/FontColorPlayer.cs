using UnityEngine;
using System;

public class FontColorPlayer : MonoBehaviour
{
    private static FontColorPlayer _instance;
    public static FontColorPlayer Instance => _instance;
    public Color color;
    public int id;
    public Color Color { get => color; set => color = value; }
    public int Id { get => id; set => id = value; }

    private static Color defaultColor = new Color(255, 255, 255);
    private void Awake()
    {
        if (_instance != null) { return; }
        _instance = this;

        DontDestroyOnLoad(this);

        id = FontColorPrefController.GetIdFontColor();
        Debug.Log("font " + id);
        if (id == 1) 
        { 
            color = defaultColor;
        } else {
            color = FontColorPrefController.GetFontColor();
        }
    }
}
