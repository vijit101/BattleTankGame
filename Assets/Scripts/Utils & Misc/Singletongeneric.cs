using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGeneric<T> where T : MonoSingletongeneric<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }
    protected virtual void OnAwake()
    {
       //Write your code here
    }
}
