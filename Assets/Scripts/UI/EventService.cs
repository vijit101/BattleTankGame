using System;

public class EventService : MonoSingletongeneric<EventService>
{
    public event Action EnemyOnDeath;
    public event Action OnEnemyKill;
    public event Action OnBulletFired;
    //public event Action OnbulletAchievement;
    //public event Action BulletHit;
    public void FireOnDeathEvent() => EnemyOnDeath?.Invoke();
    public void FireOnEnemyKill() => OnEnemyKill?.Invoke();
    public void FireOnBulletFired() => OnBulletFired?.Invoke();
}