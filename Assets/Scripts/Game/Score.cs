using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private void Awake() => scoreText = GetComponent<Text>();
    private void Start() => Game.Instance.OnChangeScoreEvent += SetPoint;
    private void SetPoint(int value) => scoreText.text = value.ToString();
}
