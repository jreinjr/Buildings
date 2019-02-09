﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : Building
{
    protected override int CalculateIncome()
    {
        Collider[] nearby = Physics.OverlapSphere(transform.position, 5f);
        return nearby.Length;
    }
}