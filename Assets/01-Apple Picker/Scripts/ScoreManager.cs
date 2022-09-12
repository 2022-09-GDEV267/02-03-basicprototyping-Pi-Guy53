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

    public int defScore;

    public int waveProgressionScore;

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
        else if(score > waveProgressionScore)
        {
            waveProgressionScore += score;
            appleTree.tree.newWave();
        }
    }
}