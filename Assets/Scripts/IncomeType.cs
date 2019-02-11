using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IncomeType : ScriptableObject
{
    public Resource[] resources;
    public abstract int GetIncome(Building building);
}
