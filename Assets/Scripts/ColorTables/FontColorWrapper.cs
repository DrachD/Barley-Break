using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FontColorWrapper : ColorWrapper, IPointerClickHandler
{
    // Родитель (таблица цветов заднего фона)
    private FontColorTable fontColorTable;
    private void Awake()
    {
        fontColorTable = GetComponentInParent<FontColorTable>();
        image = GetComponent<Image>();
        selectedColor = GetComponentInChildren<SelectedColor>();
        ImageDisable();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Color color = selectedColor.BackgroundColor;

        // передаем родителю color и id
        fontColorTable.SetColor(color, id);
    }
}
