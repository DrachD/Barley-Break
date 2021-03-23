using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : Coord, IPointerClickHandler
{
    private int idX;
    private int idY;
    public int IdX
    {
        get => idX;
        set => idX = value;
    }
    public int IdY
    {
        get => idY;
        set => idY = value;
    }
    private Game game;
    
    public void SetGameManager(Game game)
    {
        this.game = game;
    }
    public void MoveBlock(float x, float y, int idX, int idY)
    {
        transform.localPosition = new Vector2(x, y);
        this.idX = idX;
        this.idY = idY;
        X = x;
        Y = y;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            game.MoveNode(idX, idY);
        }
    }
}
