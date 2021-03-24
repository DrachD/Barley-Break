using UnityEngine;
using UnityEngine.UI;

public class SelectedColor : MonoBehaviour
{
    private Color backgroundColor;
    public Color BackgroundColor => backgroundColor;
    private void Awake() => backgroundColor = GetComponent<Image>().color;
}
