using UnityEngine;

public class FieldSizeChoice : MonoBehaviour
{
    [SerializeField] private BarleyBreakData[] barleyBreakDatas;
    public BarleyBreakData this[int value] => barleyBreakDatas[value];
}
