using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiObjDestroy : MonoBehaviour
{
    public destructableObject[] objsToDestroy;

    private int totalObjs;

    private void Start()
    {
        totalObjs = objsToDestroy.Length;

        for(int i = 0; i < objsToDestroy.Length; i++)
        {
            objsToDestroy[i].setUp(this);
        }
    }

    public void objDestroyed()
    {
        totalObjs--;

        if(totalObjs <=0)
        {
            Destroy(gameObject);
        }
    }
}