using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructableObject : MonoBehaviour
{
    public float health;
    public GameObject deathEffects;

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
        GameObject de = Instantiate(deathEffects, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}