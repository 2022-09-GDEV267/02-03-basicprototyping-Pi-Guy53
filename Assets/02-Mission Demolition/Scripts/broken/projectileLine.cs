using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLine : MonoBehaviour
{
    public static projectileLine S;

    public float minDist = .1f;

    private LineRenderer lineR;
    private GameObject _poi;
    private List<Vector3> points;

    private void Start()
    {
        S = this;

        lineR = GetComponent<LineRenderer>();
        lineR.enabled = false;

        points = new List<Vector3>();
    }

    public GameObject poi
    {
        get
        {
            return poi;
        }

        set
        {
            _poi = value;

            if(_poi != null)
            {
                lineR.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    public void Clear()
    {
        _poi = null;
        lineR.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        Vector3 pt = _poi.transform.position;
        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            return;
        }

        if( points.Count == 0)
        {
            Vector3 launchPosDiff = pt - Slingshot.LANUCH_POS;

            points.Add(pt + launchPosDiff);

            points.Add(pt);
            lineR.positionCount = 2;

            lineR.SetPosition(0, points[0]);
            lineR.SetPosition(1, points[1]);

            lineR.enabled = true;
        }
        else
        {
            points.Add(pt);
            lineR.positionCount = points.Count;
            lineR.SetPosition(points.Count - 1, lastPoint);
            lineR.enabled = true;
        }
    }

    public Vector3 lastPoint
    {
        get
        {
            if(points == null)
            {
                return Vector3.zero;
            }
            else
            {
                return (points[points.Count - 1]);
            }
        }
    }

    private void FixedUpdate()
    {
        if (poi == null)
        {
            if (followCamera.PoI != null)
            {
                if (followCamera.PoI.CompareTag("Projectile"))
                {
                    poi = followCamera.PoI;
                    print("!null");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        AddPoint();

        if(followCamera.PoI == null)
        {
            poi = null;

            print("IS Null");
        }
    }
}