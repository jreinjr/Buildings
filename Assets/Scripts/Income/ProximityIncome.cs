using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProximityIncome", menuName = "Construction/IncomeStream/Proximity")]
[System.Serializable]
public class ProximityIncome : IncomeStream
{
    public string closeToTag;
    public float distance;

    private int tagsFoundNearby;

    public override int CalculateIncome(Building building)
    {
        RecalculateNearbyTags(building.transform.position);
        return baseIncome * tagsFoundNearby;
    }

    private int RecalculateNearbyTags(Vector3 pos)
    {
        if (string.IsNullOrEmpty(closeToTag))
        {
            Debug.Log("Fill in CloseToTag");
            return 0;
        }

        tagsFoundNearby = 0;

        Collider[] nearby = Physics.OverlapSphere(pos, distance);

        foreach (Collider c in nearby)
        {
            if (c.CompareTag(closeToTag))
            {
                tagsFoundNearby++;
            }
        }

        return tagsFoundNearby;
    }
}
