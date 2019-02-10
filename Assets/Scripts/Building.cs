using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public int ID;

    static int _id
    {
        get
        {
            return 1;// ID;
        }
    }


    public Building()
    {
       // ID = ++_id; 
    }

    public int Income
    {
        get
        {
            return CalculateIncome();
        }
    }

    protected abstract int CalculateIncome();
}
