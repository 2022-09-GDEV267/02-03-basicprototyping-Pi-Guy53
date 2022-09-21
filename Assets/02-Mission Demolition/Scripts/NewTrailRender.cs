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

    private Transform poi;
    private Transform oldPoi;

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
        if(followCamera.PoI != null && followCamera.PoI.CompareTag("Projectile"))
        {
            poi = followCamera.PoI.transform;

            if(oldPoi != null && poi != oldPoi)
            {
                newLine = true;
            }

            oldPoi = poi;
        }

        if (poi != null)
        {
            if (newLine)
            {
                clearLine();
                newLine = false;
            }

            lineR.enabled = true;

            if ((poi.position - lastPoint).magnitude > minDist)
            {
                points.Add(poi.position);
                lastPoint = poi.position;
            }

            lineR.positionCount = points.Count;

            for (int i = 0; i < points.Count; i++)
            {
                lineR.SetPosition(i, points[i]);
            }
        }
    }

    public void clearLine()
    {
        lineR.enabled = false;

        lineR.positionCount = 0;

        points = new List<Vector3>();
    }
}