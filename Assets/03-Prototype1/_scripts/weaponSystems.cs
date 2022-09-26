using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponSystems : MonoBehaviour
{
    public Transform fireTransform;
    public float damage;
    public float range;

    public float rateOfFire;

    public GameObject bullet;
    public float velocity;

    private bool fired;

    public Image reloadImg;
    private float reloadFill;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!fired)
            {
                fire();
            }
        }

        reloadFill += Time.deltaTime * rateOfFire;
        reloadImg.fillAmount = reloadFill;
    }

    void fire()
    {
        fired = true;
        reloadFill = 0;

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