using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InitSystem : MonoBehaviour
{
    public GameObject helloARCore;
    public GameObject gameManagerMain;
    public GameObject gameManagerGameplay;
    private void Awake()
    {
#if UNITY_ANDROID
        Debug.Log("---- IF UNITY ANDROID -----");
        gameManagerMain.SetActive(true);
        helloARCore.SetActive(true);
        gameManagerGameplay.SetActive(true);
#endif
    }

}
