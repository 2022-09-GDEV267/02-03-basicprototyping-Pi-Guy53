using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    public static float bottom = -20;
    private int scoreValue;

    private applePicker apScript;

    public GameObject rottenSkin;
    public GameObject extraPointsSkin;

    private void Awake()
    {
        rottenSkin.SetActive(false);
        extraPointsSkin.SetActive(false);

        scoreValue = 100;
    }

    private void Start()
    {
        apScript = Camera.main.GetComponent<applePicker>();
    }

    public void setValue(int newValue)
    {
        scoreValue = newValue;

        if(scoreValue == 0)
        {
            rottenSkin.SetActive(true);
        }
        else if(scoreValue > ScoreManager.scoreManager.defScore)
        {
            extraPointsSkin.SetActive(true);
        }
    }

    void Update()
    {
        if(transform.position.y < bottom)
        {
            if (scoreValue != 0)
            {
                apScript.appleDestroyed();
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("basket"))
        {
            if (scoreValue == 0)
            {
                apScript.appleDestroyed();
            }
            else
            {
                ScoreManager.scoreManager.addScore(scoreValue);
            }

            Destroy(gameObject);
        }
    }
}