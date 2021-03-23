using UnityEngine;

public class FontColorPrefController
{
    private const string FONT_COLOR_R = "FONT_COLOR_R";
    private const string FONT_COLOR_G = "FONT_COLOR_G";
    private const string FONT_COLOR_B = "FONT_COLOR_B";
    private const string FONT_COLOR_A = "FONT_COLOR_A";
    private const string FONT_COLOR_ID = "FONT_COLOR_ID";

    public static void SetFontColor(Color color)
    {
        PlayerPrefs.SetFloat(FONT_COLOR_R, color.r);
        PlayerPrefs.SetFloat(FONT_COLOR_G, color.g);
        PlayerPrefs.SetFloat(FONT_COLOR_B, color.b);
        PlayerPrefs.SetFloat(FONT_COLOR_A, color.a);
    }
    public static Color GetFontColor()
    {
        float r = PlayerPrefs.GetFloat(FONT_COLOR_R);
        float g = PlayerPrefs.GetFloat(FONT_COLOR_G);
        float b = PlayerPrefs.GetFloat(FONT_COLOR_B);
        float a = PlayerPrefs.GetFloat(FONT_COLOR_A);

        return new Color(r, g, b, a);
    }
    public static void SetFontColorId(int id)
    {
        PlayerPrefs.SetInt(FONT_COLOR_ID, id);
    }
    public static int GetIdFontColor()
    {
        return PlayerPrefs.GetInt(FONT_COLOR_ID, 1);
    }
}
