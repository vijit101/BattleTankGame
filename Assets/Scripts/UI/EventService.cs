using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService : MonoSingletongeneric<EventService>
{
    public event Action OnDeath;
    //public event Action<Collider> OnUpdateScore;
    void Start()
    {
        
        //OnUpdateScore?.Invoke();
        OnDeath?.Invoke();
    }
}
