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

    void destroyThis()
    {
        Destroy(gameObject);
    }
}