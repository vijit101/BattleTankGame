using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService : MonoSingletongeneric<EventService>
{
    public event Action EnemyOnDeath;
    public event Action On100EnemyKill;
    //public event Action OnbulletAchievement;
    //public event Action BulletHit;
    public void FireOnDeathEvent()
    {
        EnemyOnDeath?.Invoke();
    }
    public void FireOn100EnemyKill()
    {
        On100EnemyKill?.Invoke();
    }
    
}