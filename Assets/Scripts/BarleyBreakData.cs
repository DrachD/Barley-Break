using UnityEngine;

[CreateAssetMenu(fileName = "Barley-Break Data", menuName = "ScriptableObjects/FieldData")]
public class BarleyBreakData : ScriptableObject
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int firstCoordX;
    [SerializeField] private int firstCoordY;
    [SerializeField] private int cameraSize;

    public int X => x;
    public int Y  => y;
    public int FirstCoordX => firstCoordX;
    public int FirstCoordY => firstCoordY;
    public int CameraSize => cameraSize;
}
