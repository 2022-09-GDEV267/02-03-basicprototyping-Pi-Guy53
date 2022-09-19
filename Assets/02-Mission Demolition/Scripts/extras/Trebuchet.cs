using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trebuchet : MonoBehaviour
{
    public GameObject bucket;
    public float offest;

    public float loadedRot;
    public float firedRot;
    public float recoilAmount;
    public float recoilTwo;

    public float fireRotSpeed;
    public float recoilRotSpeed;
    public float loadingRotSpeed;

    private float counter;

    private bool fire;

    void Update()
    {
        bucket.transform.position = transform.position + (transform.right * offest);

        if (fire)
        {
            if (counter < firedRot)
            {
                counter += fireRotSpeed * Time.deltaTime;
                transform.Rotate(0, 0, -fireRotSpeed * Time.deltaTime);
            }
            else if (counter < recoilAmount)
            {
                counter += recoilRotSpeed * Time.deltaTime;
                transform.Rotate(0, 0, recoilRotSpeed * Time.deltaTime);
            }
            else if (counter < recoilTwo)
            {
                counter += recoilRotSpeed * Time.deltaTime;
                transform.Rotate(0, 0, -recoilRotSpeed * Time.deltaTime);
            }
            else if (counter < loadedRot)
            {
                counter += loadingRotSpeed * Time.deltaTime;
                transform.Rotate(0, 0, loadingRotSpeed * Time.deltaTime);
            }
            else
            {
                counter = 0;
                transform.rotation = Quaternion.Euler(0, 0, 45);
                fire = false;
            }
        }
    }

    public void Shoot()
    {
        fire = true;
        counter = 0;
        transform.rotation = Quaternion.Euler(0, 0, 45);
    }

}