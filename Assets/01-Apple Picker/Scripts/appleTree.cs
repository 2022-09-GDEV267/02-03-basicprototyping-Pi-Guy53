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
    private int passiveWave;
    public int numOfWavesForScoreIncrease;

    public float waveProgressionPercentage;
    public int waveProggressionScore;
    private int originalProgressionScore;

    private int applesDropped;

    private void Awake()
    {
        tree = this;
    }

    void Start()
    {
        Invoke("dropApple", 2f);

        ScoreManager.scoreManager.defScore = score;

        waveCount = 1;
        passiveWave = 1;

        originalProgressionScore = waveProggressionScore;

        ScoreManager.scoreManager.addWave();
    }

    void dropApple()
    {
        GameObject thisApple = Instantiate(applePref, transform.position, transform.rotation);

        float rand = Random.Range(0, 100) + 1;

        if (rand > extraPointsDropChance)
        {
            thisApple.GetComponent<apple>().setValue(extraPoints);
            applesDropped += extraPoints;
        }
        else if (rand < rottenDropChance)
        {
            thisApple.GetComponent<apple>().setValue(0);
            applesDropped += 0;
        }
        else
        {
            thisApple.GetComponent<apple>().setValue(score);
            applesDropped += score;
        }

        Invoke("dropApple", Random.Range(appleDropRate.x, appleDropRate.y));

        if (applesDropped >= waveProggressionScore)
        {
            CancelInvoke("dropApple");

            newWave();
            applesDropped = 0;
        }
    }

    public void newWave()
    {
        speed = speed + (speed * waveProgressionPercentage);

        if (appleDropRate.x > .1f)
        {
            appleDropRate.x -= waveProgressionPercentage;
        }

        appleDropRate.y += (waveProgressionPercentage / waveCount);

        changeDirChance = changeDirChance + (changeDirChance * (waveProgressionPercentage / waveCount));

        Invoke("startNextWave", 3);
    }

    void startNextWave()
    {
        CancelInvoke("dropApple");

        waveCount++;
        passiveWave++;

        if (passiveWave > numOfWavesForScoreIncrease)
        {
            passiveWave = 0;
            waveProggressionScore += originalProgressionScore;

            Camera.main.GetComponent<applePicker>().addLife();
        }

        ScoreManager.scoreManager.addWave();

        applesDropped = 0;

        Invoke("dropApple", 2);
    }

    public void resetAppleDrop()
    {
        CancelInvoke("dropApple");
        applesDropped = 0;

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