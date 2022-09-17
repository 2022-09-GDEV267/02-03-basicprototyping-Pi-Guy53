using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public float easing = .05f;
    public Vector2 minXY = Vector2.zero;

    public static GameObject PoI;

    private float camZ;
    private Vector3 destination;

    private void Start()
    {
        camZ = transform.position.z;
    }

    private void FixedUpdate()
    {
        if(PoI != null)
        {
            destination = PoI.transform.position;

            destination.x = Mathf.Max(minXY.x, destination.x);
            destination.y = Mathf.Max(minXY.y, destination.y);
            destination = Vector3.Lerp(transform.position, destination, easing);

            destination.z = camZ;
            transform.position = destination;

            Camera.main.orthographicSize = destination.y + 10;
        }
    }
}