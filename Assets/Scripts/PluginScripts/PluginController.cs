using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginController : MonoBehaviour
{
    void Awake()
    {
        ToastPlugin.Init();
    }

    public class ToastPlugin
    {
        private const string CLASS_NAME = "com.example.toastplugin.ToastPlugin";
        private static AndroidJavaClass javaClass;

        public static void Init()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            javaClass = new AndroidJavaClass(CLASS_NAME);
#endif
        }

        public static void Show(string text, bool isLong)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (javaClass != null) javaClass.CallStatic("Show", text, isLong);
#endif
        }
    }
}
