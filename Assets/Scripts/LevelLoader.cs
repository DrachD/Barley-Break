using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        PluginController.ToastPlugin.Show("Главное меню", false);
        SceneLoader.ResetScenes();
        ClickSound();
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadStartGame()
    {
        PluginController.ToastPlugin.Show("Начать игру", false);
        ClickSound();
        SceneManager.LoadScene("StartGame");
    }

    public void LoadGame3x3()
    {
        PluginController.ToastPlugin.Show("3x3", false);
        SelectedField.BarleyBreakData = FindObjectOfType<FieldSizeChoice>()[0];
        ClickSound();
        SceneManager.LoadScene("Game");
    }

    public void LoadGame4x4()
    {
        PluginController.ToastPlugin.Show("4x4", false);
        SelectedField.BarleyBreakData = FindObjectOfType<FieldSizeChoice>()[1];
        ClickSound();
        SceneManager.LoadScene("Game");
    }

    public void LoadGame5x5()
    {
        PluginController.ToastPlugin.Show("5x5", false);
        SelectedField.BarleyBreakData = FindObjectOfType<FieldSizeChoice>()[2];
        ClickSound();
        SceneManager.LoadScene("Game");
    }

    public void LoadShop()
    {
        PluginController.ToastPlugin.Show("Магазин", false);
        ClickSound();
        SceneManager.LoadScene("Shop");
    }

    public void LoadSetting()
    {
        PluginController.ToastPlugin.Show("Настройки", false);
        ClickSound();
        SceneManager.LoadScene("Setting");
    }

    public void LoadOptions()
    {
        PluginController.ToastPlugin.Show("Опция", false);
        ClickSound();
        SceneManager.LoadScene("Options");
    }

    public void GameQuit()
    {
        PluginController.ToastPlugin.Show("Выход из игры", false);
        ClickSound();
        Application.Quit();
    }

    // Game manipulations
    public void ResetGame()
    {
        PluginController.ToastPlugin.Show("сброс", false);
        ClickSound();
        FindObjectOfType<Game>().gameReset = true;
    }

    // Click Sound
    public void ClickSound()
    {
        FindObjectOfType<SFXPlayer>().ClickSoundActive();
    }
}
