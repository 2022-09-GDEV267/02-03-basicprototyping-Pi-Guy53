using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class applePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets;
    public float basketBottom;
    public float basketSpacing;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.y = basketBottom + (basketSpacing * i);

            GameObject thisBasket = Instantiate(basketPrefab, pos, transform.rotation);
            basketList.Add(thisBasket);
        }
    }

    public void appleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("apple");

        for(int i = 0; i < tAppleArray.Length; i++)
        {
            Destroy(tAppleArray[i]);
        }

        GameObject tbasket = basketList[basketList.Count - 1];

        basketList.Remove(tbasket);
        Destroy(tbasket);

        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("Main-ApplePicker");
        }

        appleTree.tree.resetAppleDrop();
    }
}