using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileDamage : MonoBehaviour
{
    public float damage;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        damage = Mathf.Abs(rb.velocity.magnitude);
        //current Impact damage is between 22 and 28
    }
}