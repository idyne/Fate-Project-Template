using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FateGames.Core
{
    public static class ObjectPooler
    {
        private static Dictionary<string, ObjectPool> table;

        public static void Initialize()
        {
            table = new();
            ObjectPool[] pools = Resources.FindObjectsOfTypeAll<ObjectPool>();
            for (int i = 0; i < pools.Length; i++)
            {
                ObjectPool pool = pools[i];
                table.Add(pool.Tag, pool);
            }
        }

        public static void Get(string tag)
        {
            if (table.ContainsKey(tag))
                table[tag].Get();
            else
            {
                Debug.LogError(tag + " pool does not exist");
            }
        }

        public static void ClearPools()
        {
            foreach (ObjectPool pool in table.Values)
            {
                pool.ClearPool();
            }
        }
    }
}

