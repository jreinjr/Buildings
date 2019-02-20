using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public InventoryChangedEvent OnInventoryChanged = new InventoryChangedEvent(); 

    private Dictionary<Resource, int> resourceAmountDictionary;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        resourceAmountDictionary = new Dictionary<Resource, int>();
        foreach(Resource resource in System.Enum.GetValues(typeof(Resource)))
        {
            if (resourceAmountDictionary.ContainsKey(resource) == false)
            {
                resourceAmountDictionary.Add(resource, 0);
            }
            else
            {
                resourceAmountDictionary[resource] = 0;
            }
        }
    }

    public void AddResourceAmount(Resource resource, int amount)
    {
        if (amount < 0 && !CanAfford(resource, -amount))
        {
            Debug.LogErrorFormat("Can't afford this reduction in {0}", resource);
        }

        ChangeResource(resource, amount);
    }

    public int GetResourceAmount(Resource resource)
    {
        return resourceAmountDictionary[resource];
    }

    public bool CanAfford(Resource resource, int cost)
    {
        return resourceAmountDictionary[resource] >= cost;
    }

    public bool TryPurchase(Resource resource, int cost)
    {
        if (!CanAfford(resource, cost)) return false;

        ChangeResource(resource, -cost);
        return true;
    }

    protected void ChangeResource(Resource resource, int amount)
    {
        if (amount != 0)
        {
            resourceAmountDictionary[resource] += amount;

            if(OnInventoryChanged != null)
                OnInventoryChanged.Invoke(this);
        }
    }
}

public class InventoryChangedEvent : UnityEvent<Inventory> { }