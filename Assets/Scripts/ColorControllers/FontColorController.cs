using UnityEngine;
using UnityEngine.UI;

public class FontColorController : MonoBehaviour
{
    private Text text;
    private void Awake()
    {
        //FindObjectOfType<FontColorPlayer>().OnChangedFontColorEvent += SetFontColor;
        text = GetComponent<Text>();
    }
    private void Start()
    {
        //text.color = FindObjectOfType<FontColorPlayer>().Color;
        text.color = FindObjectOfType<JsonSystem>().data.fontColor;
    }

    public void SetFontColor(Color color)
    {
        text.color = color;
    }
}
