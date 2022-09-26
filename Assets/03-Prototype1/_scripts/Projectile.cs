using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;

    public void setUp(float lifeTime, float _damage)
    {
        damage = _damage;
        Invoke("destroyThis", lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            destroyThis();
        }
    }

    void destroyThis()
    {
        Destroy(gameObject);
    }
}