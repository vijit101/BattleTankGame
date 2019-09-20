using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementService : MonoBehaviour
{
    private void Start()
    {
        EventService.Instance.On100EnemyKill += EnemyKillAchievement;
    }

    private void EnemyKillAchievement()
    {
        Debug.LogError("$$ 100 Kills Tank Sniper $$");
    }

    private void OnDisable()
    {
        EventService.Instance.On100EnemyKill -= EnemyKillAchievement;
    }
}
