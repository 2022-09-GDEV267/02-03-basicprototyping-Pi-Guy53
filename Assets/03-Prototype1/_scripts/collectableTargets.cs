using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class collectableTargets : MonoBehaviour
{
    public float speed;
    public float turningSpeed;
    public float stoppingDist;

    public float viewRange;

    public int numSampleRunPoints;
    public float sampleRadius;

    private NavMeshAgent nav;
    private GameObject player;

    private int state;

    public GameObject legs;
    private Vector3 legPos;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        nav.angularSpeed = turningSpeed;
        nav.stoppingDistance = stoppingDist;

        player = GameObject.FindGameObjectWithTag("Player");

        legPos = legs.transform.position - transform.position;

        state = 0;
    }

    private void Update()
    {
        if (state == 0)
        {
            if (!nav.hasPath || nav.pathStatus == NavMeshPathStatus.PathPartial)
            {
                millAbout();
            }

            legs.transform.position = transform.position + legPos;
        }
        else if (state == 1)
        {
            if (!nav.hasPath || nav.pathStatus == NavMeshPathStatus.PathPartial)
            {
                runAway();
            }

            legs.transform.position = transform.position + legPos;
        }
    }

    private void FixedUpdate()
    {
        if(state == 0)
        {
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out RaycastHit hit, viewRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    state = 1;
                }
            }
        }
    }

    void millAbout()
    {
        nav.destination = transform.position + (transform.forward * Random.Range(-sampleRadius, sampleRadius)) + (transform.right * Random.Range(-sampleRadius, sampleRadius));
    }

    void runAway()
    {
        nav.speed = speed * 2;

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

    void collected()
    {
        scoreManager.scoreM.addScore(1);

        state = 2;
        GetComponent<Collider>().enabled = false;
        nav.enabled = false;

        GetComponent<Animator>().SetBool("dead", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Projectile>())
        {
            collected();
        }
    }
}