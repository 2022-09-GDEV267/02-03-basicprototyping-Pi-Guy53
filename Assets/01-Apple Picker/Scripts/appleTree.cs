using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePref;

    public float speed;
    public float leftRightBounds;
    public float changeDirChance;
    public Vector2 appleDropRate;

    private Vector3 pos;

    public float extraPointsDropChance;
    public float rottenDropChance;

    public int score, extraPoints;

    public static appleTree tree;
    private int waveCount;
    public float waveProgressionPercentage;

    private void Awake()
    {
        tree = this;
    }

    void Start()
    {
        Invoke("dropApple", 2f);

        ScoreManager.scoreManager.defScore = score;

        waveCount = 1;
    }

    void dropApple()
    {
        GameObject thisApple = Instantiate(applePref, transform.position, transform.rotation);

        float rand = Random.Range(0, 100) + 1;

        if (rand > extraPointsDropChance)
        {
            thisApple.GetComponent<apple>().setValue(extraPoints);
        }
        else if (rand < rottenDropChance)
        {
            thisApple.GetComponent<apple>().setValue(0);
        }
        else
        {
            thisApple.GetComponent<apple>().setValue(score);
        }

        Invoke("dropApple", Random.Range(appleDropRate.x, appleDropRate.y));
    }

    public void newWave()
    {
        speed = speed + (speed *( waveProgressionPercentage / waveCount));

        if (appleDropRate.x > 0)
        {
            appleDropRate.x -= waveProgressionPercentage;
        }
        if (appleDropRate.y > .25)
        {
            appleDropRate.y -= (waveProgressionPercentage / waveCount);
        }

        changeDirChance = changeDirChance + (changeDirChance * (waveProgressionPercentage / waveCount));

        waveCount++;

        resetAppleDrop();
    }

    public void resetAppleDrop()
    {
        CancelInvoke("dropApple");
        Invoke("dropApple", 2);
    }

    void Update()
    {
        pos = transform.position;
        pos.x += Random.Range(speed * .75f, speed * 1.25f) * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftRightBounds)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x >leftRightBounds)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}