using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        // Json
        cam.backgroundColor = FindObjectOfType<JsonSystem>().data.backgroundColor;
        // PrefPlayer
        //cam.backgroundColor = FindObjectOfType<BackgroundColorPlayer>().Color;
    }

    public void SetBackgroundColor(Color color)
    {
        cam.backgroundColor = color;
    }
}
