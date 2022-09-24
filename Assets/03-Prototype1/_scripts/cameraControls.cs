using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControls : MonoBehaviour
{
    public float lerpSpeed = .05f;
    public float xSensitivity, ySensitivity;

    private float x, y;

    private playerController player;
    private GameObject cam;

    private void Start()
    {
        player = GameObject.FindObjectOfType<playerController>();
        cam = Camera.main.gameObject;
    }

    void Update()
    {
        transform.position = player.transform.position;;

        /*
        if (Input.mousePosition.x > cam.GetComponent<Camera>().scaledPixelWidth - 30)
        {
            x = 1;
        }
        else if(Input.mousePosition.x < 30)
        {
            x = -1;
        }
        else
        {
            x = Input.GetAxis("Mouse X");
        }

        transform.Rotate(0, x * xSensitivity, 0);
        */
        y = Input.GetAxis("Mouse Y");

        cam.transform.Rotate(-y * ySensitivity, 0, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, player.basePiece.transform.rotation, lerpSpeed);

        Cursor.lockState = CursorLockMode.Confined;
    }
}