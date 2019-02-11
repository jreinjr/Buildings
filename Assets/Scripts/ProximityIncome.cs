using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProximityIncome", menuName = "Construction/IncomeType/Proximity")]
public class ProximityIncome : IncomeType
{
    public string closeToTag;
    public float distance;
    public float amount;

    public override int GetIncome(Building building)
    {

        int result = 0;

        Collider[] nearby = Physics.OverlapSphere(building.transform.position, distance);

        foreach (Collider c in nearby)
        {
            if (c.CompareTag(closeToTag))
            {
                result++;
            }
        }

        resource.AddResource(result);

        return result;
    }
}
