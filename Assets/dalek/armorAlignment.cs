using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorAlignment : MonoBehaviour
{
    public Transform lookPoint;

    [ContextMenu("Align Armor")]
    public void alignArmor()
    {
        transform.LookAt(lookPoint.transform.position);
    }
}