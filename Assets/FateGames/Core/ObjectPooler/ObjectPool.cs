using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FateGames.Core
{
    [CreateAssetMenu(menuName = "Fate/Object Pooling/Object Pool")]
    [System.Serializable]
    public class ObjectPool : ScriptableObject
    {
        [SerializeField] private string tag;
        private Queue<PooledObject> pool = new();
        [SerializeField] private GameObject prefab;

        public string Tag { get => tag; }

        public PooledObject Get()
        {
            if (pool.Count == 0)
                AddObjectToPool();
            PooledObject pooledObject = pool.Dequeue();
            pooledObject.OnObjectSpawn();
            return pooledObject;
        }

        private void AddObjectToPool()
        {
            PooledObject pooledObject = Object.Instantiate(prefab).GetComponent<PooledObject>();
            pooledObject.OnRelease += () => { pool.Enqueue(pooledObject); };
            pool.Enqueue(pooledObject);
        }

        public void ClearPool()
        {
            pool = new();
        }

    }
}

