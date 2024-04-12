using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
public class Bullet_Destroyer : MonoBehaviour
{
    [SerializeField] Generic2dTriggerEnter generic2DTrigger;
    private void OnEnable()
    {
        generic2DTrigger.TriggerEnterEvent += TriggerEnter2D;
    }
    private void OnDisable()
    {
        generic2DTrigger.TriggerEnterEvent -= TriggerEnter2D;
    }
    private void TriggerEnter2D(GameObject other)
    {
        if (!other.CompareTag(Tags.Bullet))
            return;
        Bullet_Info fire = other.GetComponent<Bullet_Info>();
        if (fire != null)
            fire.DestroyBullet();
    }
}
