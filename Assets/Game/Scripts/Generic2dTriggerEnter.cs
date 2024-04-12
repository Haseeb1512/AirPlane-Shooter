using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Generic2dTriggerEnter : MonoBehaviour
{
    public Action<GameObject> TriggerEnterEvent = null;
    public Action<GameObject> TriggerExitEvent = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEnterEvent?.Invoke(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TriggerExitEvent?.Invoke(collision.gameObject);
    }
}
