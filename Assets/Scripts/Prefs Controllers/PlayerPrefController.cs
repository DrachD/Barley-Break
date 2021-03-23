using UnityEngine;

public class PlayerPrefController : MonoBehaviour
{
    private BackgroundColorPlayer backgroundColorPlayer;
    private Color backgroundColor;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        //BackgroundColorPrefController.GetBackgroundColor();
        //SetBackgroundColor(backgroundColor);
    }
    public void SetBackgroundColor(Color color)
    {
        backgroundColor = color;
        FindObjectOfType<Camera>().backgroundColor = color;
    }
}
