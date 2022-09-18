using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTrailRender : MonoBehaviour
{
    public static NewTrailRender S;

    public float minDist = .1f;

    private Vector3 lastPoint;
    private LineRenderer lineR;

    private List<Vector3> points;

    private bool newLine = false;

    private void Awake()
    {
        S = this;
        lineR = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        points = new List<Vector3>();

        lastPoint = Slingshot.LANUCH_POS;
    }

    private void FixedUpdate()
    {
        if (followCamera.PoI != null && followCamera.PoI.CompareTag("Projectile"))
        {
            if (newLine)
            {
                clearLine();
                newLine = false;
            }

            lineR.enabled = true;

            if ((followCamera.PoI.transform.position - lastPoint).magnitude > minDist)
            {
                points.Add(followCamera.PoI.transform.position);
                lastPoint = followCamera.PoI.transform.position;
            }

            lineR.positionCount = points.Count;

            for (int i = 0; i < points.Count; i++)
            {
                lineR.SetPosition(i, points[i]);
            }
        }
        else
        {
            newLine = true;
        }
    }

    public void clearLine()
    {
        lineR.enabled = false;

        lineR.positionCount = 0;

        points = new List<Vector3>();
    }
}