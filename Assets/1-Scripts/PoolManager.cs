using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PoolManager : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public string ObjectName;
        public Queue<GameObject> PooledObjects;
        public GameObject objectPrefabs;
        public GameObject ParentObject;
        public int poolsize;
    }
    [SerializeField] public Pool[] pools = null;
    



    private void Start()
    {
        
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].PooledObjects = new Queue<GameObject>();
                for (int k = 0; k < pools[i].poolsize; k++)
                {
                    GameObject obj = GameManager.Instance.spawnScript.Spawn(pools[i].objectPrefabs, pools[i].ParentObject);
               
                    obj.SetActive(false);
                    pools[i].PooledObjects.Enqueue(obj);
                }
            }
        
    }
   

    public GameObject GetPoolObject(int objectType)
    {

        if (objectType >= pools.Length)
        {
            return null;
        }
        if (pools[objectType].PooledObjects.Count == 0)
        {
            AddSizePool(5f,objectType);
        }
        GameObject obj = pools[objectType].PooledObjects.Dequeue();
        obj.SetActive(true);
        return obj;
    }
    
    public void SetPoolObject(GameObject poolObject,int objectType)
    {
        
        
        if (objectType >= pools.Length)
        {
            return;
        }
        pools[objectType].PooledObjects.Enqueue(poolObject);
        poolObject.SetActive(false);
    }

    public void AddSizePool(float amount,int objectType)
    {
        
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = GameManager.Instance.spawnScript.Spawn(pools[objectType].objectPrefabs, pools[objectType].ParentObject);
            obj.SetActive(false);
            pools[objectType].PooledObjects.Enqueue(obj);
        }
    }

}
