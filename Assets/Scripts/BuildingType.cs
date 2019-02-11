using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Building", menuName= "Construction/BuildingType")]
public class BuildingType : ScriptableObject
{
    [SerializeField]
    public IncomeType incomeType;
    [SerializeField]
    public int[] test;

    public int Income { get { return _income; } }
    protected int _income;

    public int CalculateIncome(Building building)
    {
        if (incomeType == null)
            return 0;
        _income = incomeType.GetIncome(building);
        return _income;
    }
}
