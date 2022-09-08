using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets;
    public float basketBottom;
    public float basketSpacing;

    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.y = basketBottom + (basketSpacing * i);

            GameObject thisBasket = Instantiate(basketPrefab, pos, transform.rotation);
        }
    }
}