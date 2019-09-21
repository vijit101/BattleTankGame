using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI Lives, Score;
    // Start is called before the first frame update
    void Start()
    {
        EventService.Instance.EnemyOnDeath += EnemyKilledCount;
        Score.text = "Enemies Killed :" + PlayerPrefs.GetFloat("Score").ToString();
    }

    // Update is called once per frame
    // need to implement observer Pattern fully
    void Update()
    {
        onPlayerDeath();
        Debug.LogError("Enemy Killed till now" + PlayerPrefs.GetFloat("Score"));
    }
    private void onPlayerDeath()
    {
        Lives.text = "Lives :" + PlayerPrefs.GetInt("Lives").ToString();
        Score.text = "Enemies Killed :" + PlayerPrefs.GetFloat("Score").ToString();
    }
    private void EnemyKilledCount()
    {
        int killed = (int)PlayerPrefs.GetFloat("Score");
        if (killed >= 2)
        {
            //EventService.Instance.FireGenericEvent(EventService.Instance.On100EnemyKill); Won't work
            EventService.Instance.FireOnEnemyKill();
        }
    }
    private void OnDisable()
    {
        EventService.Instance.EnemyOnDeath -= EnemyKilledCount;
    }
}
