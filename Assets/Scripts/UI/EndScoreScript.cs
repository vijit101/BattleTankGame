using UnityEngine;
using TMPro;
public class EndScoreScript : MonoBehaviour
{
    public TextMeshProUGUI HighText, CurrentText;
    // Start is called before the first frame update
    private void Start()
    {
        int current = (int)PlayerPrefs.GetFloat("Score");
        CurrentText.text = "Current Score :" + current.ToString();
        HighText.text = "High Score :" + PlayerPrefs.GetInt("HighScore").ToString();
        int high = PlayerPrefs.GetInt("HighScore");
        if (high < current)
        {
            PlayerPrefs.SetInt("HighScore", current);
            HighText.text = "High Score :" + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            HighText.text = "High Score :" + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}
