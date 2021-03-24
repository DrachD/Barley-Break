using UnityEngine;
using UnityEngine.UI;

public class ImageColorController : MonoBehaviour
{
    private Image image;
    public Color Color { set => image.color = value; }
    private void Awake() => image = GetComponent<Image>();
    private void Start() => image.color = FindObjectOfType<JsonSystem>().data.fontColor;
}
