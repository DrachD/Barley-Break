using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void SetPoint(int value)
    {
        text.text = value.ToString();
    }
}
