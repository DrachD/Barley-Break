using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{
    private Color color;
    private void Start()
    {
        color = GetComponent<Image>().color;
    }

    public Color GetBackgroundColor()
    {
        return color;
    }
}
