using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlatIncome", menuName = "Construction/IncomeType/Flat")]
public class FlatIncome : IncomeType
{
    public int amount;

    public override int GetIncome(Building building)
    {
        if (resource == null)
            return 0;

        resource.AddResource(amount);

        return amount;
    }
}
