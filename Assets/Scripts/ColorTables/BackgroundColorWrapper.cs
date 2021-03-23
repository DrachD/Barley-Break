using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BackgroundColorWrapper : ColorWrapper, IPointerClickHandler
{
    // Родитель (таблица цветов заднего фона)
    private BackgroundColorTable backgroundColorTable;
    private void Awake()
    {
        backgroundColorTable = GetComponentInParent<BackgroundColorTable>();
        image = GetComponent<Image>();
        selectedColor = GetComponentInChildren<SelectedColor>();
        ImageDisable();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Color color = selectedColor.BackgroundColor;

        // передаем родителю color и id
        backgroundColorTable.SetColor(color, id);
    }
}
