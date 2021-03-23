using UnityEngine;

public class BackgroundSelected : MonoBehaviour
{
    private int currentImageIdSelected;
    public int CurrentImageIdSelected { get => currentImageIdSelected; set => currentImageIdSelected = value; }
    [SerializeField] private ImageSelected[] imageSelecteds;

    private void Awake()
    {
        // Задайте текущий выбранный фон из PlayerSavedPrefController
        //currentImageIdSelected = FindObjectOfType<BackgroundColorPlayer>().GetBackgroundSelected();
        imageSelecteds = GetComponentsInChildren<ImageSelected>();
    }
    void Start()
    {
        SetDataOnImageSelected();
    }

    private void SetDataOnImageSelected()
    {
        int i = 0;
        foreach (ImageSelected img in imageSelecteds)
        {
            img.Id = i;
            img.DisableImage();

            if (currentImageIdSelected == i)
            {
                img.EnableImage();
            }

            i++;
        }
    }

    public void SetNewImage(int id)
    {
        imageSelecteds[currentImageIdSelected].DisableImage();

        imageSelecteds[id].EnableImage();    

        currentImageIdSelected = id;
    }
}
