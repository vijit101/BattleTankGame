using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{

    private static ObjectPooler instance;
    public static ObjectPooler Instance { get { return instance; } }
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
    public List<ObjectPoolItem> itemsToPool;

    private void Start()
    {
        InstantPool();
    }
    private void Awake()
    {
        instance = this;
    }

    public void InstantPool()
    {
        pooledObjects = new List<GameObject>();
        foreach(ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject gmo = Instantiate(item.objectToPool) as GameObject;
                gmo.SetActive(false);
                pooledObjects.Add(gmo);
            }
        }
        
    }

    public GameObject GetPooledObject(String tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }            
        }
        foreach(ObjectPoolItem items in itemsToPool)
        {
            if(items.objectToPool.tag == tag)
            {
                if (items.shouldExpand)
                {
                    GameObject obj = Instantiate(items.objectToPool) as GameObject;
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }

            }
        }
        return null;

    }
    
}
[Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
}
