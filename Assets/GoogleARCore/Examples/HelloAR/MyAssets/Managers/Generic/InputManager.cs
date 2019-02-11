using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public Camera firstPersonCamera;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TouchAction?.Invoke(Input.GetTouch(0).position);
        }

    }


    public event Action<Vector2> TouchAction;
}
