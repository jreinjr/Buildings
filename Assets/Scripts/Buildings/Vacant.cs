using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacant : Building
{
    protected override int CalculateIncome()
    {
        return 0;
    }
}
