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
        Lives.text = "Lives :"+PlayerPrefs.GetInt("Lives").ToString();
        Score.text = "Score :" + PlayerPrefs.GetFloat("Score").ToString();
    }

    // Update is called once per frame
    // need to implement observer Pattern fully
    void Update()
    {
        onPlayerDeath();
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
}
