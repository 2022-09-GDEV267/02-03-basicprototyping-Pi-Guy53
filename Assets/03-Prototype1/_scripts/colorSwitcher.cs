using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorSwitcher : MonoBehaviour
{
    public Color[] armorColor;
    public Color[] shieldColor;

    public int armorInt;
    public int shieldInt;

    public Material armorPlate;
    public Material shieldNode;

    public GameObject body;
    public GameObject shields;

    private Vector3 originalPos;

    public float switchSpeed;
    public float switchDistance;

    private bool switchingArmor, switchingShields;
    private float switchArmorCount, switchShieldsCount;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("ArmorColorInt"))
        {
            armorInt = PlayerPrefs.GetInt("ArmorColorInt");
        }

        if (PlayerPrefs.HasKey("ShieldColorInt"))
        {
            shieldInt = PlayerPrefs.GetInt("ShieldColorInt");
        }

        PlayerPrefs.SetInt("ArmorColorInt", armorInt);
        PlayerPrefs.SetInt("ShieldColorInt", shieldInt);
    }

    private void Start()
    {
        originalPos = body.transform.position;
    }

    private void Update()
    {
        if (switchingArmor)
        {
            switchArmorCount += Time.deltaTime * switchSpeed;

            body.transform.position += transform.right * Time.deltaTime * -switchSpeed;

            if (switchArmorCount > switchDistance * 2)
            {
                switchingArmor = false;
                body.transform.position = originalPos;
            }
            else if (switchArmorCount > switchDistance + (switchSpeed * Time.deltaTime))
            { }
            else if (switchArmorCount > switchDistance)
            {
                body.transform.position = originalPos + transform.right * switchDistance;
                armorPlate.color = armorColor[armorInt];
            }

        }

        if (switchingShields)
        {
            switchShieldsCount += Time.deltaTime * switchSpeed;

            shields.transform.position += transform.right * Time.deltaTime * -switchSpeed;

            if (switchShieldsCount > switchDistance * 2)
            {
                switchingShields = false;
                shields.transform.position = originalPos;
            }
            else if (switchShieldsCount > switchDistance + (switchSpeed * Time.deltaTime))
            { }
            else if (switchShieldsCount > switchDistance)
            {
                shields.transform.position = originalPos + transform.right * switchDistance;
                shieldNode.color = shieldColor[shieldInt];
            }

        }
    }

    [ContextMenu("Switch Armor Color")]
    public void SwitchArmorColor()
    {
        if (!switchingArmor)
        {
            if (armorInt < armorColor.Length - 1)
            {
                armorInt++;
            }
            else
            {
                armorInt = 0;
            }

            PlayerPrefs.SetInt("ArmorColorInt", armorInt);

            switchingArmor = true;
            switchArmorCount = 0;
        }
    }

    [ContextMenu("Switch Shield Color")]
    public void SwitchShieldColor()
    {
        if (!switchingShields)
        {
            if (shieldInt < shieldColor.Length - 1)
            {
                shieldInt++;
            }
            else
            {
                shieldInt = 0;
            }

            PlayerPrefs.SetInt("ShieldColorInt", shieldInt);

            switchingShields = true;
            switchShieldsCount = 0;
        }
    }
}