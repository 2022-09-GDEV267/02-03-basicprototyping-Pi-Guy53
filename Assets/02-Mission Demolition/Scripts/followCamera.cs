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

    Rigidbody pRb;

    private void Start()
    {
        camZ = transform.position.z;
    }

    private void FixedUpdate()
    {
        if(PoI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = PoI.transform.position;

            if (PoI.CompareTag("Projectile"))
            {
                pRb = PoI.GetComponent<Rigidbody>();

                pRb.sleepThreshold = .1f;

                if (pRb.IsSleeping())
                {
                    PoI = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);

        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 12;
    }
}