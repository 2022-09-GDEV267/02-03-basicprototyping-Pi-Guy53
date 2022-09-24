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

    private void Start()
    {
        if (PlayerPrefs.HasKey("ArmorColorInt"))
        {
            armorInt = PlayerPrefs.GetInt("ArmorColorInt");
        }

        if (PlayerPrefs.HasKey("ShieldColorInt"))
        {
            armorInt = PlayerPrefs.GetInt("ShieldColorInt");
        }

        PlayerPrefs.SetInt("ArmorColorInt", armorInt);
        PlayerPrefs.SetInt("ShieldColorInt", shieldInt);
    }

    [ContextMenu("Switch Armor Color")]
    public void SwitchArmorColor()
    {
        if(armorInt < armorColor.Length - 1)
        {
            armorInt++;
        }
        else
        {
            armorInt = 0;
        }

        PlayerPrefs.SetInt("ArmorColorInt", armorInt);

        armorPlate.color = armorColor[armorInt];
    }

    [ContextMenu("Switch Shield Color")]
    public void SwitchShieldColor()
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

        shieldNode.color = shieldColor[shieldInt];
    }
}