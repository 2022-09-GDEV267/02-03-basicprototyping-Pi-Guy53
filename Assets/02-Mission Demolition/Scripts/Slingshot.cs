using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    private static Slingshot S;

    public GameObject projectilePrefab;
    public float velocityMulti;

    public Transform launchPoint;
    private Vector3 launchPos;

    private bool aimingMode;

    private GameObject thisProjectile;
    private Rigidbody projectileRb;

    float maxMagnitude;

    private Vector3 mousePos2D, mousePos3D, mouseDelta;


    public GameObject aimTargetPref;
    public int numOfAimT;
    private List<GameObject> aimTList;
    private float aimT;

    public static Vector3 LANUCH_POS
    {
        get
        {
            if(S== null)
            {
                return Vector3.zero;
            }
            else
            {
                return S.launchPos;
            }
        }
    }

    private void Awake()
    {
        S = this;
    }

    private void Start()
    {
        launchPos = launchPoint.position;

        launchPoint.gameObject.SetActive(false);
        maxMagnitude = GetComponent<SphereCollider>().radius;

        GameObject thisAim;

        aimTList = new List<GameObject>();

        for (int i = 0; i < numOfAimT; i++)
        {
            thisAim = Instantiate(aimTargetPref, transform.position, transform.rotation);

            aimTList.Add(thisAim);
            thisAim.SetActive(false);
        }
    }

    private void Update()
    {
        if (aimingMode)
        {
            mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            mouseDelta = mousePos3D - launchPos;

            if (mouseDelta.magnitude > maxMagnitude)
            {
                mouseDelta.Normalize();
                mouseDelta *= maxMagnitude;
            }

            thisProjectile.transform.position = launchPos + mouseDelta;

            targeting();

            if (Input.GetMouseButtonUp(0))
            {
                aimingMode = false;

                projectileRb.isKinematic = false;
                projectileRb.AddForce(-mouseDelta * velocityMulti, ForceMode.Impulse);

                followCamera.PoI = thisProjectile;
                thisProjectile = null;

                MissionDemolition.shotFired();
            }
        }
    }

    private void OnMouseEnter()
    {
        launchPoint.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        launchPoint.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true;

        thisProjectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);

        projectileRb = thisProjectile.GetComponent<Rigidbody>();
        projectileRb.isKinematic = true;
    }

    void targeting()
    {
        aimT += Time.deltaTime;

        if (aimTList.Count == numOfAimT)
        {
            if (aimT > .25f)
            {
                for (int i = 0; i < aimTList.Count; i++)
                {
                    if (!aimTList[i].activeInHierarchy)
                    {
                        aimTList[i].SetActive(true);
                        aimTList[i].transform.position = thisProjectile.transform.position;
                        aimTList[i].GetComponent<Rigidbody>().AddForce(-mouseDelta * velocityMulti, ForceMode.Impulse);

                        i = aimTList.Count;
                    }
                }

                aimT = 0;
            }
        }
    }
}