using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager scoreM;

    public int score;
    public Text scoreTxt;

    public int winScore;

    private void Awake()
    {
        scoreM = this;
    }

    public void addScore(int addScore)
    {
        score += addScore;

        //scoreTxt.text = "Exterminated: " + score;

        if (score >= winScore)
        {
            //Win
        }
    }
}