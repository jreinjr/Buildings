using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public int Income
    {
        get
        {
            return CalculateIncome();
        }
    }

    protected abstract int CalculateIncome();
}
