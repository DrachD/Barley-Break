using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Awake()
    {
        BackgroundColorPrefController.GetBackgroundColor();
        //GetComponent<Camera>().orthographicSize = Find
    }
}
