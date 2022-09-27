using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructableObject : MonoBehaviour
{
    public float health;
    public GameObject deathEffects;

    private bool inUse;
    private MultiObjDestroy mod;

    public void setUp(MultiObjDestroy _mod)
    {
        mod = _mod;
        inUse = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<Projectile>())
        {
            health -= collision.collider.GetComponent<Projectile>().damage;

            if(health <= 0)
            {
                destroyed();
            }
        }
    }

    void destroyed()
    {
        if (deathEffects != null)
        {
            GameObject de = Instantiate(deathEffects, transform.position, transform.rotation);
        }

        if(inUse)
        {
            mod.objDestroyed();
        }

        Destroy(gameObject);
    }
}