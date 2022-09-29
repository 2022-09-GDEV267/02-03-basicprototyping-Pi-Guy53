using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private GameObject player;

    public GameObject barrel;

    public int shotsToFireInBurst;
    public float rateOfFire;
    public float reloadTime;

    public float range, velocity;

    public GameObject bulletPref;

    private int shotsFired;
    private bool fired;

    private List<GameObject> bullets;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        bullets = new List<GameObject>();

        for (int i = 0; i < shotsToFireInBurst; i++)
        {
            GameObject thisBullet = Instantiate(bulletPref, transform.position, transform.rotation);

            bullets.Add(thisBullet);

            thisBullet.SetActive(false);
        }

        fired = false;
        Invoke("recoil", reloadTime);
    }

    void Update()
    {
        barrel.transform.LookAt(player.transform.position);

        shoot();
    }

    GameObject getBullet()
    {
        for(int i = 0; i < shotsToFireInBurst; i++)
        {
            if(!bullets[i].activeInHierarchy)
            {
                return bullets[i];
            }
        }

        return null;
    }

    void shoot()
    {
        if (!fired)
        {
            if (shotsFired < shotsToFireInBurst)
            {
                GameObject thisBullet = getBullet();

                thisBullet.SetActive(true);

                thisBullet.transform.position = barrel.transform.position;
                thisBullet.transform.rotation = barrel.transform.rotation;

                thisBullet.GetComponent<bullet>().setUp(range / velocity);
                thisBullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * velocity, ForceMode.Impulse);

                fired = true;

                Invoke("recoil", rateOfFire);

                shotsFired++;
            }
            else
            {
                fired = true;
                Invoke("reload", reloadTime);
            }
        }
    }

    void recoil()
    {
        CancelInvoke("recoil");
        fired = false;
    }

    void reload()
    {
        CancelInvoke("reload");
        fired = false;
        shotsFired = 0;
    }
}