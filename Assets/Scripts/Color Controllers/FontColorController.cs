using UnityEngine;
using UnityEngine.UI;

public class FontColorController : MonoBehaviour
{
    private Text text;
    public Color Color
    {
        set => text.color = value;
    }
    private void Awake() => text = GetComponent<Text>();
    private void Start() => Color = ColorPlayer.Instance.FontColor;
}
