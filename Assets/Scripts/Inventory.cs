using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text inventoryText;
    public Resource[] resources;

    private void Start()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            resources[i].Reset();
        }
    }

    public void UpdateInventoryText()
    {
        if (inventoryText == null)
        {
            throw new MissingReferenceException();
        }

        inventoryText.text = resources[0].Current.ToString();
    }


}
