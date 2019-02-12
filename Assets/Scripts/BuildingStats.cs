using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingStats", menuName = "Construction/BuildingStats")]
public class BuildingStats : ScriptableObject
{
    public ResourceType resourceCost;
    public int cost = 100;
    public int maxHP = 10;
    public int maxPop = 5;
}
