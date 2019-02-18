using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ResourceCost
{
    public ResourceType type;
    public int cost;

    public ResourceCost(ResourceType type, int cost) : this()
    {
        this.cost = cost;
        this.type = type;
    }
}

[CreateAssetMenu(fileName = "BuildingStats", menuName = "Construction/BuildingStats")]
public class BuildingStats : ScriptableObject
{
    public ResourceCost[] resourceCost;
    public int maxHP = 10;
    public int maxPop = 5;
    public int maxJobs = 0;

    public BuildingStats()
    {
        if (resourceCost == null)
        {
            resourceCost = new ResourceCost[]{ new ResourceCost(ResourceType.Gold, 100) };
        }
    }
}
