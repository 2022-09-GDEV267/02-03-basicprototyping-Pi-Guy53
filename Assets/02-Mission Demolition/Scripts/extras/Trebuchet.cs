using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trebuchet : MonoBehaviour
{
    public GameObject bucket;
    public float offest;

    public float loadedRot;
    public float firedRot;
    public float recoilAmount;

    private float counter;

    void Update()
    {
        bucket.transform.position = transform.position + (transform.right * offest);


    }

}