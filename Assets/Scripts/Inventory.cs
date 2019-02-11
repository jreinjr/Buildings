using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text inventoryText;
    public Resource resource;

    public void UpdateInventoryText()
    {
        if (inventoryText == null)
        {
            throw new MissingReferenceException();
        }

        inventoryText.text = resource.Current.ToString();
    }
}
