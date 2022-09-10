using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    Vector3 mousePos2D;
    Vector3 mousePos3D;
    Vector3 pos;

    private void Update()
    {
        mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        pos = this.transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.CompareTag("apple"))
        {
            Destroy(coll.collider.gameObject);
        }
    }
}