using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Pool
{
    public class Pool_Manager : MonoBehaviour
    {
        public IObjectPool<GameObject> pool;
        public GameObject objectToPool;
        protected IObjectPool<GameObject> pooledObjects;
        //public List<GameObject> pooledObjects;
        public int maxPoolSize = 10;
        public bool collectionChecks = true;
        protected virtual void Awake()
        {
        
            pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
           
            
        }
        GameObject CreatePooledItem()
        {
            GameObject go = Instantiate(objectToPool);
           

            return go;
        }
        // Called when an item is returned to the pool using Release
        void OnReturnedToPool(GameObject system)
        {
            system.transform.SetParent(this.transform);
            system.gameObject.SetActive(false);
        }

        // Called when an item is taken from the pool using Get
        void OnTakeFromPool(GameObject system)
        {
            system.gameObject.SetActive(true);
        }

        // If the pool capacity is reached then any items returned will be destroyed.
        // We can control what the destroy behavior does, here we destroy the GameObject.
        void OnDestroyPoolObject(GameObject system)
        {
            Destroy(system.gameObject);
        }
        public GameObject GetObj()
        {
            return pool.Get();
        }
        public void Release(GameObject obj)
        {
            pool.Release(obj);
        }
    }
}