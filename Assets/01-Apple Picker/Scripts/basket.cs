using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreTxt;

    Vector3 mousePos2D;
    Vector3 mousePos3D;
    Vector3 pos;

    private void Start()
    {
        GameObject scoreGo = GameObject.Find("score");
        scoreTxt = scoreGo.GetComponent<Text>();
        scoreTxt.text = "0";
    }

    private void Update()
    {
        mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        pos = this.transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("apple"))
        {
            Destroy(coll.collider.gameObject);

            int score = int.Parse(scoreTxt.text);
            score += 100;

            scoreTxt.text = score.ToString();

            if(score > highScore.score)
            {
                highScore.score = score;
            }
        }
    }
}