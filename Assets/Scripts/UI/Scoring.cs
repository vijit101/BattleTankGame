using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI Lives, Score,Gameover;
    // Start is called before the first frame update
    void Start()
    {
        EventService.Instance.EnemyOnDeath += EnemyKilledCount;
        PlayerPrefs.SetInt("EnemyKiledCount", 0);
        Lives.text = "Lives :"+PlayerPrefs.GetInt("Lives").ToString();
        Score.text = "Score :" + PlayerPrefs.GetFloat("Score").ToString();
    }

    // Update is called once per frame
    // need to implement observer Pattern fully
    void Update()
    {
        onPlayerDeath();
        Debug.LogError("Enemy Killed till now"+ PlayerPrefs.GetInt("EnemyKiledCount"));
    }
    private void onPlayerDeath()
    {
        Lives.text = "Lives :" + PlayerPrefs.GetInt("Lives").ToString();
        Score.text = "Score :" + PlayerPrefs.GetFloat("Score").ToString();
        if (PlayerPrefs.GetInt("Lives") == 0)
        {
            Gameover.enabled = true;
        }
    }
    private void EnemyKilledCount()
    {
        int killed = PlayerPrefs.GetInt("EnemyKiledCount");
        killed++;
        PlayerPrefs.SetInt("EnemyKiledCount", killed);
        if(killed == 100)
        {
            //EventService.Instance.FireGenericEvent(EventService.Instance.On100EnemyKill); Won't work
            EventService.Instance.FireOn100EnemyKill();
        }
    }
    private void OnDisable()
    {
        EventService.Instance.EnemyOnDeath -= EnemyKilledCount;
    }
}
