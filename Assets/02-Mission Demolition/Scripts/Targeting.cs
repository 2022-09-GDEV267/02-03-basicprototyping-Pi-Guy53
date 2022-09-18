using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("destroyThis", 2);
    }

    private void destroyThis()
    {
        gameObject.SetActive(false);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}