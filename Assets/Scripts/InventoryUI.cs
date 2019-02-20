using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;

    public Text gold_text;
    public Text food_text;
    public Text culture_text;
    public Text wood_text;
    public Text stone_text;

    private void Start()
    {
        inventory.OnInventoryChanged.AddListener(InventoryChanged);
    }

    void InventoryChanged(Inventory inventory)
    {
        gold_text.text = "Gold: " + inventory.GetResourceAmount(Resource.Gold);
        food_text.text = "Food: " + inventory.GetResourceAmount(Resource.Food);
        culture_text.text = "Culture: " + inventory.GetResourceAmount(Resource.Culture);
        wood_text.text = "Wood: " + inventory.GetResourceAmount(Resource.Wood);
        stone_text.text = "Stone: " + inventory.GetResourceAmount(Resource.Stone);
    }
}
