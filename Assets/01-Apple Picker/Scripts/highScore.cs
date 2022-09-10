using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScore : MonoBehaviour
{
    static public int score = 1000;

    void Update()
    {
        Text scoreTxt = this.GetComponent<Text>();
        scoreTxt.text = "High Score: " + score;
    }
}