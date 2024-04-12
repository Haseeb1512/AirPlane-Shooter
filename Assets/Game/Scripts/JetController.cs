using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetController : MonoBehaviour
{
    [SerializeField] AirController AirController;
    [SerializeField] Fire fire;
    private void OnEnable()
    {
        AirController.MovingEvent += Control;
    }
    private void OnDisable()
    {
        AirController.MovingEvent -= Control;
    }

    void Control()
    {
        fire.FireEvent?.Invoke();
    }
}
