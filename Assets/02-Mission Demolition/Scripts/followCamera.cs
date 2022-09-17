using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public static GameObject PoI;

    private float camZ;
    private Vector3 destination;

    private void Start()
    {
        camZ = transform.position.z;
    }

    private void FixedUpdate()//
    {
        if(PoI != null)
        {
            destination = PoI.transform.position;
            destination.z = camZ;
            transform.position = destination;
        }
    }
}