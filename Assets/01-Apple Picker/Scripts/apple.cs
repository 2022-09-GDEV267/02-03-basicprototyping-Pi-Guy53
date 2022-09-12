using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    public static float bottom = -20;
    public int scoreValue;

    private applePicker apScript;

    private void Start()
    {
        applePicker apScript = Camera.main.GetComponent<applePicker>();
    }

    void Update()
    {
        if(transform.position.y < bottom)
        {
            apScript.appleDestroyed();

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("basket"))
        {
            ScoreManager.scoreManager.addScore(scoreValue);

            Destroy(gameObject);
        }
    }
}