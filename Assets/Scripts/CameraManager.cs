using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Game gameManager;

    private void Start() => cam.orthographicSize = gameManager.CameraSize;
}
