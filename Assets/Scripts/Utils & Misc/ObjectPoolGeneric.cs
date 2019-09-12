using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.utils
{
    public class ObjectPoolGeneric<T> : MonoSingletongeneric<ObjectPoolGeneric<T>> where T : class
    {
        private List<PooledItem<T>> PooledItems = new List<PooledItem<T>>();

        public virtual T GetPoolItem()
        {
            if (PooledItems.Count > 0)
            {
                PooledItem<T> poolobj = PooledItems.Find(i => i.isUsed == false);// foreach(item i in pooleditem){if(!item.isused)return item.item}           
                if (poolobj != null)
                {
                    poolobj.isUsed = true;
                    return poolobj.poolItem;
                }
                return CreateNewPoolObjNow();
            }
            return CreateNewPoolObjNow();
        }

        public virtual T CreateNewPoolObjNow()
        {
            PooledItem<T> NewPoolObj = new PooledItem<T>();
            NewPoolObj.poolItem = CreateItem();
            NewPoolObj.isUsed = true;
            PooledItems.Add(NewPoolObj);
            return NewPoolObj.poolItem;
        }
        protected virtual T CreateItem()
        {
            return null;
        }
        public virtual void ReturnPooledObject(T ReturnedItem)
        {
            PooledItem<T> returnItem = PooledItems.Find(i => i.poolItem == ReturnedItem);//If not working use .equals
            returnItem.isUsed = false;
            return;
        }

        private class PooledItem<T>
        {
            public T poolItem;  //using m to represent the member functions of a class
            public bool isUsed;
        }
    }

}

