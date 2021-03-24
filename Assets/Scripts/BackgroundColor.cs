using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{
    private Color color;
    public Color Color => color;
    private void Start() => color = GetComponent<Image>().color;
}
