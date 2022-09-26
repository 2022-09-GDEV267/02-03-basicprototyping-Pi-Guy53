using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSystems : MonoBehaviour
{
    public Transform fireTransform;
    public float damage;
    public float range;

    public float rateOfFire;

    public GameObject bullet;
    public float velocity;

    private bool fired;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!fired)
            {
                fire();
            }
        }
    }

    void fire()
    {
        fired = true;

        GameObject thisShot = Instantiate(bullet, fireTransform.transform.position, fireTransform.transform.rotation);
        thisShot.GetComponent<Projectile>().setUp(range / velocity, damage);

        thisShot.GetComponent<Rigidbody>().AddForce(fireTransform.transform.forward * velocity, ForceMode.Impulse);

        Invoke("recoil", rateOfFire);
    }

    void recoil()
    {
        fired = false;
    }
}