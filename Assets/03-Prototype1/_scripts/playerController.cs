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
    public GameObject eyeStalk;

    public GameObject weapon;

    private GameObject eye;

    private Rigidbody rb;
    private Vector3 direction;
    public float rotationalLerp = .05f;

    private Vector3 mousePos3D;
    private RaycastHit hit;

    public LayerMask ignoreMouseLayer;

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

        //movement
        rb.velocity = (direction * speed);

        //resets the direction if no input
        if (direction.magnitude == 0)
        {
            direction = basePiece.transform.forward;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f, ignoreMouseLayer))
        {
            mousePos3D = hit.point;
        }

        eye.transform.LookAt(mousePos3D);

        //model rotations/positions
        basePiece.transform.rotation = Quaternion.Lerp(basePiece.transform.rotation, Quaternion.LookRotation(direction.normalized), rotationalLerp);

        head.transform.localRotation = Quaternion.Euler(0, eye.transform.localEulerAngles.y, 0);
        eyeStalk.transform.localRotation = Quaternion.Euler(eye.transform.localEulerAngles.x, 0, 0);
    }

    private void FixedUpdate()
    {

    }
}