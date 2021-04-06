using UnityEngine;

public class PanelController : MonoBehaviour
{
    // нажатие на крест
    public void WinPanelDisabled() => gameObject.SetActive(false);
    // срабатывает при завершении игры
    public void WinPanelEnabled() 
    { 
        gameObject.SetActive(true);  
        Game.Instance.gameOver = true;
    }
    private void Awake() => Game.Instance.OnWonEvent += WinPanelEnabled;
    private void Start() => gameObject.SetActive(false);
    // нажатие на кнопку попытаться снова и сбросить все значения
    public void WinPanelTryAgain()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.AUDIO_clickSFX);
        WinPanelDisabled();
        Game.Instance.ResetGame();
    }
}
