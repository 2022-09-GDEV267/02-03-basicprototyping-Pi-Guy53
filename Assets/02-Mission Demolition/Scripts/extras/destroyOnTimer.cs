using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnTimer : MonoBehaviour
{
    public float timeToDestroy;

    private void Start()
    {
        Invoke("destroyThis", timeToDestroy);
    }

    void destroyThis()
    {
        Destroy(gameObject);
    }
}