using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float x, y;
    private float inputAxis;

    public float speed;
    public float jumpHeight;
    private int jumpState = 0;
    private RaycastHit groundHit;

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

    void Update()//
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        direction = body.transform.forward * y + body.transform.right * x;

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

        crossHairs.transform.position = cam.GetComponent<Camera>().WorldToScreenPoint(mousePos3D);

        eye.transform.LookAt(mousePos3D);

        weapon.transform.LookAt(mousePos3D);

        //Jump/Hover System//
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpState < 2)
            {
                jumpState++;
            }
            else
            {
                jumpState = 0;
            }

            if (Physics.Raycast(transform.position, transform.up * 1, (jumpHeight * jumpState) + .75f, ignoreMouseLayer))
            {
                jumpState = 0;
            }
        }

        Physics.Raycast(transform.position, transform.up * -1, out groundHit, jumpHeight * 3, ignoreMouseLayer);

        //model rotations/positions

        basePiece.transform.rotation = Quaternion.Lerp(basePiece.transform.rotation, Quaternion.LookRotation(direction.normalized), rotationalLerp);

        head.transform.localRotation = Quaternion.Euler(0, eye.transform.localEulerAngles.y, 0);
        eyeStalk.transform.localRotation = Quaternion.Euler(eye.transform.localEulerAngles.x, 0, 0);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, groundHit.point + transform.up * ((jumpHeight * jumpState) + .75f), .025f);

        Vector3 weaponVector = weapon.transform.forward;
        weaponVector.y = 0;

        if (Vector3.Angle(weapon.transform.forward, body.transform.forward) > maxWeaponRot && Vector3.Distance(transform.position, mousePos3D) > 1)
        {
            body.transform.localRotation = Quaternion.Lerp(body.transform.rotation, Quaternion.LookRotation(weaponVector), rotationalLerp);
        }
    }
}