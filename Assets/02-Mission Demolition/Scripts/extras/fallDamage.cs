using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDamage : MonoBehaviour
{
    public float health;

    private float damage;
    private Rigidbody rb;

    public GameObject destroyEffects;

    private bool allowForSetteling;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        allowForSetteling = true;
        Invoke("setteled", 1);
    }

    void setteled()
    {
        allowForSetteling = false;
    }

    private void FixedUpdate()
    {
        damage = Mathf.Abs(rb.velocity.magnitude);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!allowForSetteling)
        {
            if (collision.collider.CompareTag("Projectile"))
            {
                damage += collision.gameObject.GetComponent<projectileDamage>().damage;
            }
            else
            {
                if (collision.gameObject.GetComponent<fallDamage>())
                {
                    damage += collision.gameObject.GetComponent<fallDamage>().damage;
                }
            }

            health -= damage;

            if (health < 0)
            {
                GameObject theseEffects = Instantiate(destroyEffects, transform.position, transform.rotation);

                Destroy(gameObject);
            }
        }
    }
}