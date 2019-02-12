using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public abstract class IncomeStream : ScriptableObject
{
    public ResourceType resource;
    public int baseIncome;

    public virtual void GenerateIncome(Building building)
    {
        int income = CalculateIncome(building);

        GameManager.Inventory.AddResourceAmount(resource, income);
    }

    public virtual int CalculateIncome(Building building)
    {
        return baseIncome;
    }
}