using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] Joystick joystick = null;
    public static Func<Joystick> GetJoyStick_Event;
    [SerializeField] Camera cam = null;
    public static Func<Camera> GetCameraEvent;
    private void OnEnable()
    {
        GetJoyStick_Event += GetJoyStick;
        GetCameraEvent += GetCamera;
    }
    private void OnDisable()
    {
        GetJoyStick_Event -= GetJoyStick;
        GetCameraEvent -= GetCamera;
    }
    

    Joystick GetJoyStick()
    {
        return joystick;
    }
    Camera GetCamera()
    {
        return cam;
    }
}
