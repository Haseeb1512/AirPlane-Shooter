using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
namespace Bullet
{
    public class Bullet_Info : MonoBehaviour
    {
        [SerializeField] Rigidbody2D rig;
        public Rigidbody2D _Rigidbody => rig;
        protected Pool_Manager _PoolManager;
        public void Initialize(Pool_Manager pool)
        {
            _PoolManager = pool;
        }
        public void DestroyBullet()
        {
            _PoolManager.Release(this.gameObject);
        }
      
    }
}