using UnityEngine;
using System;

public class FontColorTable : ColorTable
{
    private FontColorController[] fontColorController;
    
    protected override void LogicAwake()
    {
        fontColorController = FindObjectsOfType<FontColorController>();
    }

    protected override void LogicStart()
    {
        currentColorIdSelected = FindObjectOfType<JsonSystem>().JsonData.fontId;
    }
    
    protected override void SetColor(ColorWrapper colorWrapper)
    {
        // переносим опять в производный класс
        // Json Save System
        foreach (FontColorController font in fontColorController)
        {
            font.Color = colorWrapper.Color;
        } 

        FindObjectOfType<JsonSystem>().JsonData.fontColor = colorWrapper.Color;
        FindObjectOfType<JsonSystem>().JsonData.fontId = colorWrapper.Id;
        FindObjectOfType<JsonSystem>().SaveData();

        ColorPlayer.Instance.FontColor = colorWrapper.Color;
        ColorPlayer.Instance.FontId = colorWrapper.Id;

        base.SetColor(colorWrapper);
    }
}
