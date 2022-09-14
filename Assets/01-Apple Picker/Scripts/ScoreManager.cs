using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    private int score;
    private int tempScore;

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
        tempScore += addScore;

        score += addScore;

        scoreTxt.text = score.ToString();

        if (score > highScore.score)
        {
            highScore.score = score;
        }
    }

    public void consolodateScore()
    {
        tempScore = 0;
    }

    public void lostLife()
    {
        score -= tempScore;
        scoreTxt.text = score.ToString();
    }

    public void addWave(int value)
    {
        waveCount += value;
        waveCountTxt.text = "Wave: " + waveCount;
    }
}