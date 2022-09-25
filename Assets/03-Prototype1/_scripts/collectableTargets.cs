using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class collectableTargets : MonoBehaviour
{
    public float speed;
    public float turningSpeed;
    public float stoppingDist;

    public int numSampleRunPoints;
    public float sampleRadius;

    private NavMeshAgent nav;
    private GameObject player;

    private int state;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        nav.angularSpeed = turningSpeed;
        nav.stoppingDistance = stoppingDist;

        player = GameObject.FindGameObjectWithTag("Player");

        //debug
        state = 1;
    }

    private void Update()
    {
        if(state == 0)
        {
            
        }
        else if(state == 1)
        {
            if (!nav.hasPath || nav.pathStatus == NavMeshPathStatus.PathPartial)
            {
                runAway();
            }
        }
    }

    void millAbout()
    {

    }

    void runAway()
    {
        Vector3 samplePoint;
        Vector3 winSample = transform.position;

        float dist = 0;

        for(int i = 0; i < numSampleRunPoints; i++)
        {
            samplePoint = transform.position + (transform.forward * Random.Range(-sampleRadius, sampleRadius)) + (transform.right * Random.Range(-sampleRadius, sampleRadius));

            float tDist = Vector3.Distance(samplePoint, player.transform.position);

            if (tDist > dist)
            {
                winSample = samplePoint;
                dist = tDist;
            }
        }

        nav.destination = winSample;
    }
}