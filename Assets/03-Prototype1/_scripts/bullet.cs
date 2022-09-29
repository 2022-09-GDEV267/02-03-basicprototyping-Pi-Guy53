using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<TrailRenderer>().Clear();
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void setUp(float timer)
    {
        GetComponent<TrailRenderer>().Clear();
        Invoke("destroyThis", timer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke("destroyThis", .5f);
        }
        else
        {
            destroyThis();
        }
    }

    void destroyThis()
    {
        gameObject.SetActive(false);
    }
}