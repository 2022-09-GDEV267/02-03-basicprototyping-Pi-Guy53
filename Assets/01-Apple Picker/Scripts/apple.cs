using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    public static float bottom = -20;

    void Update()
    {
        if(transform.position.y < bottom)
        {
            applePicker apScript = Camera.main.GetComponent<applePicker>();
            apScript.appleDestroyed();

            Destroy(gameObject);
        }
    }
}