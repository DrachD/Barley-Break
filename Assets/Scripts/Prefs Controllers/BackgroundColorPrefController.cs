using UnityEngine;

public class BackgroundColorPrefController
{
    private const string BACKGROUND_COLOR_R = "BACKGROUND_COLOR_R";
    private const string BACKGROUND_COLOR_G = "BACKGROUND_COLOR_G";
    private const string BACKGROUND_COLOR_B = "BACKGROUND_COLOR_B";
    private const string BACKGROUND_COLOR_A = "BACKGROUND_COLOR_A";
    private const string BACKGROUND_COLOR_ID = "BACKGROUND_COLOR_ID";

    public static void SetBackgroundColor(Color color)
    {
        PlayerPrefs.SetFloat(BACKGROUND_COLOR_R, color.r);
        PlayerPrefs.SetFloat(BACKGROUND_COLOR_G, color.g);
        PlayerPrefs.SetFloat(BACKGROUND_COLOR_B, color.b);
        PlayerPrefs.SetFloat(BACKGROUND_COLOR_A, color.a);
    }
    public static Color GetBackgroundColor()
    {
        float r = PlayerPrefs.GetFloat(BACKGROUND_COLOR_R);
        float g = PlayerPrefs.GetFloat(BACKGROUND_COLOR_G);
        float b = PlayerPrefs.GetFloat(BACKGROUND_COLOR_B);
        float a = PlayerPrefs.GetFloat(BACKGROUND_COLOR_A);

        return new Color(r, g, b, a);
    }
    public static void SetBackgroundColorId(int id)
    {
        PlayerPrefs.SetInt(BACKGROUND_COLOR_ID, id);
    }
    public static int GetIdBackgroundColor()
    {
        return PlayerPrefs.GetInt(BACKGROUND_COLOR_ID, 0);
    }
}
