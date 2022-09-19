using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionDemolition : MonoBehaviour
{
    public enum GameMode { idle, playing, levelEnd }

    public static MissionDemolition S;

    public Text levelTxt;
    public Text shotsTxt;
    public Text buttonTxt;

    public Vector3 castlePos;
    public GameObject[] castles;

    private int level;
    public int shotsTaken;

    private GameObject currentCastle;

    public GameMode mode = GameMode.idle;
    private string showing = "Show Slingshot";

    public GameObject viewBoth;

    private void Awake()
    {
        S = this;
    }

    void Start()
    {
        level = 0;

        startLevel();
    }

    void startLevel()
    {
        if(currentCastle != null)
        {
            Destroy(currentCastle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        currentCastle = Instantiate(castles[level], castlePos, transform.rotation);

        shotsTaken = 0;
        switchView("Show Both");
        NewTrailRender.S.clearLine();

        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        levelTxt.text = "Level: " + (level + 1) + " of " + castles.Length;
        shotsTxt.text = "Shots Taken: " + shotsTaken;
    }

    private void Update()
    {
        UpdateGUI();

        if (mode == GameMode.playing && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            switchView("Show Both");

            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;

        if (level == castles.Length)
        {
            level = 0;
        }

        startLevel();
    }

    public void switchView(string eview = "")
    {
        if (eview == "")
        {
            eview = buttonTxt.text;
        }

        showing = eview;

        switch (showing)
        {
            case "Show Slingshot":
                followCamera.PoI = null;
                buttonTxt.text = "Show Castle";
                break;
            case "Show Castle":
                followCamera.PoI = castles[level];
                buttonTxt.text = "Show Both";
                break;
            case "Show Both":
                followCamera.PoI = viewBoth;
                buttonTxt.text = "Show Slingshot";
                break;
        }
    }

    public static void shotFired()
    {
        S.shotsTaken++;
    }
}