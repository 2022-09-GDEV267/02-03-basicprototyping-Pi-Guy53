using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float x, y;
    private float inputAxis;

    public float speed;
    public float jumpTime;

    public GameObject basePiece;
    public GameObject body;
    public GameObject head;
    public GameObject eyeStalk;

    public GameObject weapon;

    public float maxWeaponRot;

    private GameObject eye;

    private Rigidbody rb;
    private Vector3 direction;
    public float rotationalLerp = .05f;

    public Vector3 mousePos3D;
    private RaycastHit hit;

    public GameObject crossHairs;

    public LayerMask ignoreMouseLayer;

    private GameObject cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        eye = new GameObject("eye");
        eye.transform.position = eyeStalk.transform.position;
        eye.transform.parent = transform;

        cam = Camera.main.gameObject;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        direction = basePiece.transform.forward * y + basePiece.transform.right * x;

        inputAxis = Mathf.Clamp(Mathf.Abs(x) + Mathf.Abs(y), 0, 1);

        //movement
        rb.velocity = (direction.normalized * (speed * inputAxis));

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

        crossHairs.transform.position = mousePos3D;
        crossHairs.transform.LookAt(cam.transform.position);

        eye.transform.LookAt(mousePos3D);

        weapon.transform.LookAt(mousePos3D);

        //model rotations/positions
        Vector3 weaponVector = weapon.transform.forward;
        weaponVector.y = 0;

        if (Vector3.Angle(weapon.transform.forward, body.transform.forward) > maxWeaponRot)
        {
            body.transform.localRotation = Quaternion.Lerp(body.transform.rotation, Quaternion.LookRotation(weaponVector), rotationalLerp);
        }

        basePiece.transform.rotation = Quaternion.Lerp(basePiece.transform.rotation, Quaternion.LookRotation(direction.normalized), rotationalLerp);

        head.transform.localRotation = Quaternion.Euler(0, eye.transform.localEulerAngles.y, 0);
        eyeStalk.transform.localRotation = Quaternion.Euler(eye.transform.localEulerAngles.x, 0, 0);
    }

    private void FixedUpdate()
    {

    }
}