using UnityEngine;
using System;

public class BackgroundColorTable : ColorTable
{
    // cache data
    private BackgroundColorPlayer backgroundColorPlayer;
    // Задний фон камеры
    private BackgroundColorController backgroundColorController;
    // список оберток
    private BackgroundColorWrapper[] backgroundColorWrappers;
    private void Awake()
    {
        backgroundColorWrappers = GetComponentsInChildren<BackgroundColorWrapper>();
        backgroundColorController = FindObjectOfType<BackgroundColorController>();
        backgroundColorPlayer = FindObjectOfType<BackgroundColorPlayer>();

        //currentColorIdSelected = backgroundColorPlayer.Id;
    }
    private void Start()
    {
        currentColorIdSelected = FindObjectOfType<JsonSystem>().data.backgroundId;
        SetIdForImageSelected();
    }

    void SetIdForImageSelected() {
        for (int i = 0; i < backgroundColorWrappers.Length; i++)
        {
            backgroundColorWrappers[i].Id = i;

            if (i == currentColorIdSelected)
            {
                backgroundColorWrappers[i].ImageEnable();
            }
        }
    }
    // реакция на нажатие выбираемого цвета
    public void SetColor(Color color, int id)
    {
        // Pref Save System
        //backgroundColorPlayer.Color = color;
        //backgroundColorPlayer.Id = id;
        //backgroundColorController.SetBackgroundColor(color);

        // Json Save System
        backgroundColorController.BackgroundColor = color;
        FindObjectOfType<JsonSystem>().data.backgroundColor = color;
        FindObjectOfType<JsonSystem>().data.backgroundId = id;
        FindObjectOfType<JsonSystem>().SaveData();

        // ВНИМАНИЕ! Есть смысл вынести выполнение данного метода на завершение приложения в целях оптимизации
        //BackgroundColorPrefController.SetBackgroundColor(color);
        //BackgroundColorPrefController.SetBackgroundColorId(id);

        // Включаем и отключаем оберки выбранных и невыбранных цветов
        EnableNDisableWrapper(id);
    }
    protected void EnableNDisableWrapper(int id)
    {
        backgroundColorWrappers[currentColorIdSelected].ImageDisable();
        backgroundColorWrappers[id].ImageEnable();

        currentColorIdSelected = id;
    }
}
