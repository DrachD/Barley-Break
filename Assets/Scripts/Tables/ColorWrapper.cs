using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorWrapper : MonoBehaviour, IPointerClickHandler
{
    // Дочерние выбраннные цвета заднего фона
    protected SelectedColor selectedColor;
    protected Image image;
    public Color Color;
    public int Id;

    // Отключаем или включаем обертку в зависимости от нашего выбора
    public void ImageEnable() => image.enabled = true;
    public void ImageDisable() => image.enabled = false;
    public event Action<ColorWrapper> OnChoiceEvent; 

    private ColorTable colorTable;
    private void Awake()
    {
        colorTable = GetComponentInParent<ColorTable>();
        image = GetComponent<Image>();
        selectedColor = GetComponentInChildren<SelectedColor>();

        ImageDisable();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Color = selectedColor.BackgroundColor;
        OnChoiceEvent?.Invoke(this);

        // передаем родителю color и id
        //colorTable.SetColor(color, Id);
    }
}
