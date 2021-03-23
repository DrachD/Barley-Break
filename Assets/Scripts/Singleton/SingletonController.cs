using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Данный скрипт контроллирует все синглтоны на сцене
// это необходимо для того, чтобы любая сцена не зависила
// от другой сцены, то есть сцена в котором скрипты 
// нуждаются в каком-то
// синглтон-скрипте, автоматически создаст необходимый синглтон
public class SingletonController : MonoBehaviour
{
    // all the singleton prefabs
    [SerializeField] private MusicPlayer musicPlayerPrefab;
    [SerializeField] private SFXPlayer sfxPlayerPrefab;
    [SerializeField] private BackgroundColorPlayer backgroundColorPlayerPrefab;
    [SerializeField] private FontColorPlayer fontColorPlayerPrefab;

    private void Awake()
    {
       if (FindObjectOfType<MusicPlayer>() == null) { Instantiate(musicPlayerPrefab); }
       if (FindObjectOfType<SFXPlayer>() == null) { Instantiate(sfxPlayerPrefab); }
       // я использую json, поэтому кусок кода бесполезен, к тому же заполнит лишнюю память
       //if (FindObjectOfType<BackgroundColorPlayer>() == null) { Instantiate(backgroundColorPlayerPrefab); }
       //if (FindObjectOfType<FontColorPlayer>() == null) { Instantiate(fontColorPlayerPrefab); }
    }
}
