using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService : MonoSingletongeneric<EventService>
{
    public event Action OnDeath;
    //public event Action<Collider> OnUpdateScore;
    // Start is called before the first frame update
    void Start()
    {
        
        //OnUpdateScore?.Invoke();
        OnDeath?.Invoke();
    }
}
