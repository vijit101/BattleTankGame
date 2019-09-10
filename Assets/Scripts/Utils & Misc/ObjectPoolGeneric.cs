using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolGeneric<T> : Singletongeneric<ObjectPoolGeneric<T>> where T:class
{
    private List<PooledItem<T>> PooledItems;

    public virtual T GetPoolItem()
    {
        if(PooledItems.Count > 0)
        {
            PooledItem<T> poolobj = PooledItems.Find(i => i.m_isUsed == false);// foreach(item i in pooleditem){if(!item.isused)return item.item}
            poolobj.m_isUsed = true;
            if(poolobj.m_poolItem != null)
            {
                return poolobj.m_poolItem;
            }
            return CreateNewPoolObjNow();
        }
        return CreateNewPoolObjNow();
    }

    public virtual T CreateNewPoolObjNow()
    {
        PooledItem<T> NewPoolObj = new PooledItem<T>();
        NewPoolObj.m_poolItem = CreateItem();
        NewPoolObj.m_isUsed = true;
        PooledItems.Add(NewPoolObj);
        return NewPoolObj.m_poolItem;
    }
    protected virtual T CreateItem()
    {
        return null;
    }
    protected virtual void ReturnPooledObject(T ReturnedItem)
    {
        PooledItem<T> returnItem = PooledItems.Find(i => i.m_poolItem == ReturnedItem);//If not working use .equals
        returnItem.m_isUsed = false;
        return;
    }




#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
    private class PooledItem<T>
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
    {
        public T m_poolItem;  //using m to represent the member functions of a class
        public bool m_isUsed;
    }
}
