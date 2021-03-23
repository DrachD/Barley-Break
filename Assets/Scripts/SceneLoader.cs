using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private const int mainScene = 0;
    private static int lastScene;
    private static int currentScene;
    private static Stack<int> stackScene;

    public static void ResetScenes()
    {
        stackScene = new Stack<int>();
        lastScene = 0;
    }

    private void Awake()
    {
        StackManipulation();
    }
    private void Update()
    {
        BackButtonPressed();
    }

    private void BackButtonPressed()
    {
        if (Input.GetKey(KeyCode.Escape) && currentScene > mainScene)
        {
            PreviousLoadScene();
        }
    }

    private void PreviousLoadScene()
    {
        if (currentScene == 0) { return; }
        lastScene = currentScene;
        stackScene.Pop();
        SceneManager.LoadScene(stackScene.Pop());
    }

    private void StackManipulation()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;


        if (stackScene == null) { stackScene = new Stack<int>(); }

        stackScene.Push(currentScene);
    }
}
