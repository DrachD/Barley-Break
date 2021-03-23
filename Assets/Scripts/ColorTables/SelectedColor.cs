using UnityEngine;
using UnityEngine.UI;

public class SelectedColor : MonoBehaviour
{
    private Color backgroundColor;
    public Color BackgroundColor { get => backgroundColor; }
    private void Awake()
    {
        backgroundColor = GetComponent<Image>().color;
    }
}
