using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float velocityMulti;

    public Transform launchPoint;
    private Vector3 launchPos;

    private bool aimingMode;

    private GameObject thisProjectile;
    private Rigidbody projectileRb;

    float maxMagnitude;//

    private Vector3 mousePos2D, mousePos3D, mouseDelta;

    public Transform endPoint;
    private Transform eye;

    private void Start()
    {
        launchPos = launchPoint.position;

        launchPoint.gameObject.SetActive(false);
        maxMagnitude = GetComponent<SphereCollider>().radius;

        eye = new GameObject("eye").transform;
        eye.transform.position = transform.position;
        eye.transform.parent = transform;
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
        eye.transform.position = thisProjectile.transform.position;
        eye.transform.LookAt(launchPos);

        endPoint.transform.position = eye.transform.position + (endPoint.transform.right * ((Mathf.Deg2Rad * eye.eulerAngles.x) * ((velocityMulti * velocityMulti) / 10)));
    }
}