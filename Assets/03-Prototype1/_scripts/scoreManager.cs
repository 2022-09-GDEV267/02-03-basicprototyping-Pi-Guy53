using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager scoreM;

    public int score;
    public Text scoreText;

    public int winScore;

    private void Awake()
    {
        scoreM = this;
    }

    public void addScore(int addScore)
    {
        score += addScore;

        if (score >= winScore)
        {
            //Win
        }
    }
}