using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
public class BuildingStatReader : MonoBehaviour
{
    private Building m_Building;
    [SerializeField] [ReadOnly] private int Income;
    [SerializeField] [ReadOnly] private int ID;

    private void OnValidate()
    {
        UpdateStats();
    }

    private void OnEnable()
    {
        UpdateStats();
    }

    void UpdateStats()
    {
        m_Building = GetComponent<Building>();

        if (m_Building != null)
        {
            Income = m_Building.Income;
            ID = m_Building.ID;
        }
    }
}
