using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControls : MonoBehaviour
{
    private playerController player;
    public float lerpSpeed = .05f;

    private void Start()
    {
        player = GameObject.FindObjectOfType<playerController>();
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;

        if (Vector3.Angle(transform.forward, player.mousePos3D - transform.position) > 20)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(player.head.transform.forward), lerpSpeed);
        }
    }
}