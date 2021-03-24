using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    private Camera cam;
    public Color BackgroundColor { set => cam.backgroundColor = value; }

    private void Awake() => cam = GetComponent<Camera>();

    private void Start()
    {
        // Json
        cam.backgroundColor = FindObjectOfType<JsonSystem>().data.backgroundColor;
        // PrefPlayer
        //cam.backgroundColor = FindObjectOfType<BackgroundColorPlayer>().Color;
    }
}
