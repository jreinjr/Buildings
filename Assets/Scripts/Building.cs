using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int ID { get { return _id; } }
    private readonly int _id;
    protected static int _ID;

    public BuildingType buildingType;

    public Building()
    {
       _id = ++_ID; 
    }

    public int Income
    {
        get
        {
            return CollectIncome();
        }
    }

    public int CollectIncome()
    {
        return buildingType.CalculateIncome(this);
    }
}
