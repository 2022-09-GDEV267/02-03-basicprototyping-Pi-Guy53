using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    static public int score = 1000;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }

        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update()
    {
        Text scoreTxt = this.GetComponent<Text>();
        scoreTxt.text = "High Score: " + score;

        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}