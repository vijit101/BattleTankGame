using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletongeneric<T> : MonoBehaviour where T :Singletongeneric<T>
{
    private static T instance;
    public static T Instance{ get { return instance; } }
    private void Awake()
    {
        if(instance ==null)
        {
            instance = (T)this;
        }
        else
        {
            Destroy(this);
        }
    }
}
