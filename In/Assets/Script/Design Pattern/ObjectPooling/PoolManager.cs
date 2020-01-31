using System;
using System.Collections.Generic;
using System.Linq;
using Script.OOP;
using UnityEngine;

namespace Script.Manager
{
    public class PoolManager : MonoSingleton<PoolManager>
    {
        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;
        private Transform tr;
        public override void Init()
        {
            tr = transform;
            poolDictionary=new Dictionary<string, Queue<GameObject>>();
            for (int i = 0; i < pools.Count; i++)
            {
                poolDictionary.Add(pools[i].tag, new Queue<GameObject>());
                for (int j = 0; j < pools[i].size; j++)
                {
                    GrowPool(pools[i]);

                }
            }
        }
        public GameObject GetObject(string poolTag)
        {
            try
            {
                if (poolDictionary[poolTag].Count == 1)
                    GrowPool(poolTag);
                return poolDictionary[poolTag].Dequeue();
            }
            catch (Exception e)
            {
                Debug.Log(poolTag);
                throw;
            }


        }
        public void BackToPool(GameObject obj,string poolTag)
        {
            obj.SetActive(false);
            poolDictionary[poolTag].Enqueue(obj);
        }
        private GameObject g;
        void GrowPool(Pool pool)
        {
            g = Instantiate(pool.prefab, tr);
            g.SetActive(false);
            poolDictionary[pool.tag].Enqueue(g);
        }
        void GrowPool(string poolTag)
        {
            GrowPool(pools.First(i => i.tag == poolTag));
        }
    }
}
