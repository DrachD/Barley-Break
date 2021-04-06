using UnityEngine;

public abstract class ColorTable : MonoBehaviour
{
    public int currentColorIdSelected;
    // список оберток
    protected ColorWrapper[] colorWrapper;

    private void Awake()
    {
        LogicAwake();
        colorWrapper = GetComponentsInChildren<ColorWrapper>();
        for (int i = 0; i < colorWrapper.Length; i++)
        {
            colorWrapper[i].OnChoiceEvent += SetColor;
        }
    }
    private void Start()
    {
        LogicStart();
        SetIdForImageSelected();
    }
    private void SetIdForImageSelected() 
    {
        for (int i = 0; i < colorWrapper.Length; i++)
        {
            colorWrapper[i].Id = i;

            if (i == currentColorIdSelected)
            {
                colorWrapper[i].ImageEnable();
            }
        }
    }
    protected virtual void SetColor(ColorWrapper colorWrapper)
    {
        EnableNDisableWrapper(colorWrapper.Id);
    }
    private void EnableNDisableWrapper(int id)
    {
        colorWrapper[currentColorIdSelected].ImageDisable();
        colorWrapper[id].ImageEnable();

        currentColorIdSelected = id;
    }

    protected virtual void LogicAwake() {}
    protected virtual void LogicStart() {}
    protected virtual void LogicUpdate() {}
}
