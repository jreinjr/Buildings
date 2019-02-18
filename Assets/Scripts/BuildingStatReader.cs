using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
public class BuildingStatReader : MonoBehaviour
{
    private UniqueID m_ID;
    private Income m_Income;
    [SerializeField] [ReadOnly] private int Income;
    [SerializeField] [ReadOnly] private string ID;

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
        m_ID = GetComponent<UniqueID>();
        m_Income = GetComponent<Income>();

        if (m_ID != null)
        {
            //Income = m_Income.Income;
            ID = m_ID.ID;
        }
    }
}
