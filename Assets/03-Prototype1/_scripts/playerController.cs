using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float x, y;

    public float speed;
    public float jumpTime;

    public GameObject basePiece;
    public GameObject body;
    public GameObject head;

    public GameObject weapon;

    private GameObject eye;

    private Rigidbody rb;
    private Vector3 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        eye = new GameObject("eye");
        eye.transform.position = transform.position;
        eye.transform.parent = transform;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        direction = transform.forward * y + transform.right * x;

        rb.AddForce(direction.normalized * speed);
    }
}