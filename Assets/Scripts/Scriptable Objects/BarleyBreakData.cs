using UnityEngine;

[CreateAssetMenu(fileName = "Barley-Break Data", menuName = "ScriptableObjects/FieldData")]
public class BarleyBreakData : ScriptableObject
{
    [SerializeField] private int cols;
    [SerializeField] private int rows;
    [SerializeField] private int firstPosX;
    [SerializeField] private int firstPosY;
    [SerializeField] private int sizeField;
    [SerializeField] private int cameraSize;

    public int Cols => cols;
    public int Rows  => rows;
    public int SizeField => sizeField;
    public int FirstPosX => firstPosX;
    public int FirstPosY => firstPosY;
    public int CameraSize => cameraSize;
}
