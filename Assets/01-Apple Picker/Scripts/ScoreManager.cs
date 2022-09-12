using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    private int score;

    [Header("Set Dynamically")]
    public Text scoreTxt;

    [Header("Set In Inspector")]
    public Text waveCountTxt;

    public int defScore;

    private int waveCount;

    private void Awake()
    {
        scoreManager = this;
    }

    private void Start()
    {
        GameObject scoreGo = GameObject.Find("score");
        scoreTxt = scoreGo.GetComponent<Text>();
        scoreTxt.text = "0";
    }

    public void addScore(int addScore)
    {
        int score = int.Parse(scoreTxt.text);
        score += addScore;

        scoreTxt.text = score.ToString();

        if (score > highScore.score)
        {
            highScore.score = score;
        }
    }

    public void addWave()
    {
        waveCount++;
        waveCountTxt.text = "Wave: " + waveCount;
    }
}