using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementService : MonoBehaviour
{
    private void Start()
    {
        EventService.Instance.OnEnemyKill += EnemyKillAchievements;
        EventService.Instance.OnBulletFired += BulletAchievement;
    }

    public void BulletAchievement()
    {
        Debug.LogError("$$ Bullets Noob Medal $$");
    }

    private void EnemyKillAchievements()
    {
        Debug.LogError("$$ Tank Novice Medal $$");
    }


    private void OnDisable()
    {
        EventService.Instance.OnEnemyKill -= EnemyKillAchievements;
        EventService.Instance.OnBulletFired -= BulletAchievement;
    }
}
