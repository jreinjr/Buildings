using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public static int nextID = 0;
    public int ID { get { return _ID; } }
    private int _ID;

    [Expandable]
    public BuildingStats m_buildingStats;

    private void Awake()
    {
        _ID = nextID;
        nextID++;
    }

    
}
