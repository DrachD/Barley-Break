using UnityEngine;

public class PanelController : MonoBehaviour
{
    public void WinPanelEnabled()
    {
        gameObject.SetActive(true);
    }

    public void WinPanelDisabled()
    {
        gameObject.SetActive(false);
    }
    
    public void WinPanelTryAgain()
    {
        ClickSound();
        WinPanelDisabled();
        FindObjectOfType<Game>().gameReset = true;
    }
    public void ClickSound()
    {
        FindObjectOfType<SFXPlayer>().ClickSoundActive();
    }
}
