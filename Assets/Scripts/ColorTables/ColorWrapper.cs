using UnityEngine;
using UnityEngine.UI;

public class ColorWrapper : MonoBehaviour
{
    // Дочерние выбраннные цвета заднего фона
    protected SelectedColor selectedColor;
    // уникальный id
    protected int id;
    protected Image image;
    public int Id { set => id = value; }
    private void Start()
    {
        
    }

    // Отключаем или включаем обертку в зависимости от нашего выбора
    public void ImageEnable()
    {
        image.enabled = true;
    }

    public void ImageDisable()
    {
        image.enabled = false;
    }
}
