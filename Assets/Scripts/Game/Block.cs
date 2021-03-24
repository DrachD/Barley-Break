using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour, IPointerClickHandler
{
    // static id
    public int Id { get; set; }
    // dynamic id
    public int IdX { get; set; }
    public int IdY { get; set; }
    public Sprite Icon { get => sp.sprite; set => sp.sprite = value; }
#region Cash
    protected SpriteRenderer sp;
#endregion
    public event Action<Block> OnChangePlaceBlockEvent;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    public void Init(int id, int idX, int idY, int posX, int posY, Sprite sprite)
    {
        Id = id;
        IdX = idX;
        IdY = idY;
        transform.localPosition = new Vector2(posX, posY);
        sp.sprite = sprite;
    }
    public void MoveBlock(float posX, float posY, int idX, int idY)
    {
        transform.localPosition = new Vector2(posX, posY);
        IdX = idX;
        IdY = idY;
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            OnChangePlaceBlockEvent?.Invoke(this);
        }
    }
}