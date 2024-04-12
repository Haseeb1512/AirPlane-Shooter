using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pool;
using Bullet;
public abstract class Fire : MonoBehaviour
{

    [SerializeField] protected float FireSpeed = 20f;
    [SerializeField] protected float Wait = 250f;
    [SerializeField] protected GameObject FireLocation = null;
   
    protected Func<Bullet_Info> GetBulletEvent;
    public Action<Bullet_Info> DestoryBulletEvent;
    public Action FireEvent;
    [SerializeField] protected Pool_Manager _PoolManager;
    Vector3 _ShootVector = Vector3.up;
   
    protected virtual void OnEnable()
    {
        GetBulletEvent += GetBullet;
        DestoryBulletEvent += ReserveBullet;
        FireEvent += FireIt;
    }
    protected virtual void OnDisable()
    {
        GetBulletEvent -= GetBullet;
        DestoryBulletEvent -= ReserveBullet;
        FireEvent -= FireIt;
    }



    protected Bullet_Info GetBullet()
    {
        Bullet_Info r = null;
        r = _PoolManager.GetObj().GetComponent<Bullet_Info>();
        
        return r;
    }
    protected void ReserveBullet(Bullet_Info r)
    {
        if (r == null)
            return;
        _PoolManager.Release(r.gameObject);
    }
    protected DateTime time;


    protected virtual void FireIt()
    {
        if (time != null)
            if (DateTime.UtcNow < time)
                return;
        _ShootVector.x = 0;
        bool toggle = false;
        Vector3 temp = _ShootVector;
        for (int i = 0; i < 3; i++)
        {
            if (i > 0)
            {
                if (((i + 1) % 2) == 0)
                    _ShootVector.x += 0.05f;
                temp = _ShootVector;
                if (toggle)
                    temp.x = -temp.x;
                toggle = !toggle;
            }
                FireAt(FireLocation.transform.TransformDirection(temp));
            
        }
        time = DateTime.UtcNow;
        time = time.AddMilliseconds(Wait);

    }
    protected Bullet_Info FireAt(Vector3 direction)
    {
   
        Bullet_Info r = GetBullet();
        r.Initialize(_PoolManager);
        r.gameObject.SetActive(true);
        r._Rigidbody.velocity = Vector2.zero;
        r.gameObject.transform.SetParent(FireLocation.transform);
        r.transform.localPosition = Vector3.zero;
        r.transform.localEulerAngles = Vector3.zero;
        r.gameObject.transform.SetParent(null);
        r._Rigidbody.AddForce(FireSpeed * direction, ForceMode2D.Impulse);
        return r;
    }
}
