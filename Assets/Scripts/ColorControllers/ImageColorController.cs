using UnityEngine;
using UnityEngine.UI;

public class ImageColorController : MonoBehaviour
{
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        image.color = FindObjectOfType<JsonSystem>().data.fontColor;
    }

    public void SetFontColor(Color color)
    {
        image.color = color;
    }
}
