using UnityEngine;
using System;

public class BackgroundColorTable : ColorTable
{
    private BackgroundColorController backgroundColorController;

    protected override void LogicAwake()
    {
        backgroundColorController = FindObjectOfType<BackgroundColorController>();
    }

    protected override void LogicStart()
    {
        currentColorIdSelected = FindObjectOfType<JsonSystem>().JsonData.backgroundId;
    }
    
    protected override void SetColor(ColorWrapper colorWrapper)
    {
        // Json Save System
        backgroundColorController.BackgroundColor = colorWrapper.Color;
        FindObjectOfType<JsonSystem>().JsonData.backgroundColor = colorWrapper.Color;
        FindObjectOfType<JsonSystem>().JsonData.backgroundId = colorWrapper.Id;
        FindObjectOfType<JsonSystem>().SaveData();

        ColorPlayer.Instance.BackgroundColor = colorWrapper.Color;
        ColorPlayer.Instance.BackgroundId = colorWrapper.Id;

        base.SetColor(colorWrapper);
    }
}
