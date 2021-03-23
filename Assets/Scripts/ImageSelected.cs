using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageSelected : MonoBehaviour
{
    public int Id { set; get; }
    private Image image;

    private BackgroundSelected backgroundSelected;
    private BackgroundColor backgroundColor;

    private void Awake()
    {
        image = GetComponent<Image>();
        backgroundSelected = GetComponentInParent<BackgroundSelected>();
        backgroundColor = GetComponentInChildren<BackgroundColor>();
    }

    public void EnableImage()
    {
        image.enabled = true;
    }

    public void DisableImage()
    {
        image.enabled = false;
    }
}
