using UnityEngine;
using System;

public class FontColorTable : ColorTable
{
    private FontColorController fontColorController;
    // Cache data
    private FontColorPlayer fontColorPlayer;
    // список оберток
    protected FontColorWrapper[] fontColorWrappers;
    public event Action<Color> OnChangedFontColorEvent;

    private void Awake()
    {

        fontColorWrappers = GetComponentsInChildren<FontColorWrapper>();
        fontColorPlayer = FindObjectOfType<FontColorPlayer>();
        fontColorController = FindObjectOfType<FontColorController>();
        //currentColorIdSelected = fontColorPlayer.Id;
    }
    private void Start()
    {
        currentColorIdSelected = FindObjectOfType<JsonSystem>().data.fontId;
        SetIdForImageSelected();
    }

    void SetIdForImageSelected() {
        for (int i = 0; i < fontColorWrappers.Length; i++)
        {
            fontColorWrappers[i].Id = i;

            if (i == currentColorIdSelected)
            {
                fontColorWrappers[i].ImageEnable();
            }
        }
    }
    // реакция на нажатие выбираемого цвета
    public void SetColor(Color color, int id)
    {
        // Pref Save System
        //fontColorController.SetFontColor(color);
        //fontColorPlayer.Color = color;
        //fontColorPlayer.Id = id;

        // Json Save System
        fontColorController.SetFontColor(color);
        FindObjectOfType<JsonSystem>().data.fontColor = color;
        FindObjectOfType<JsonSystem>().data.fontId = id;
        FindObjectOfType<JsonSystem>().SaveData();

        //FindObjectOfType<FontColorController>().SetFontColor(color);
        // ВНИМАНИЕ! Есть смысл вынести выполнение данного метода на завершение приложения в целях оптимизации
        //FontColorPrefController.SetFontColor(color);
        //FontColorPrefController.SetFontColorId(id);

        // Включаем и отключаем оберки выбранных и невыбранных цветов
        EnableNDisableWrapper(id);
    }
    protected void EnableNDisableWrapper(int id)
    {
        fontColorWrappers[currentColorIdSelected].ImageDisable();
        fontColorWrappers[id].ImageEnable();

        currentColorIdSelected = id;
    }
}
