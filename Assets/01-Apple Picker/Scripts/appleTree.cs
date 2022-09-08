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
    public float appleDropRate;

    private Vector3 pos;

    void Start()
    {
        
    }

    void Update()
    {
        pos = transform.position;
        pos.x += speed * Time.deltaTime;
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