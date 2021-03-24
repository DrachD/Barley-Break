using UnityEngine;

public class PanelController : MonoBehaviour
{
    public void WinPanelEnabled() 
    { 
        gameObject.SetActive(true);  
        Game.Instance.gameOver = true;
    }
    public void WinPanelDisabled() => gameObject.SetActive(false);
    private void Awake() => Game.Instance.OnWonEvent += WinPanelEnabled;
    private void Start() => gameObject.SetActive(false);
    public void WinPanelTryAgain()
    {
        SFXPlayer.Instance.ClickSoundActive();
        WinPanelDisabled();
        Game.Instance.ResetGame();
    }
}
