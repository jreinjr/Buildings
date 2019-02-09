using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
[ExecuteInEditMode]
public class BuildingStatReader : MonoBehaviour
{
    private Building m_Building;
    [SerializeField] [ReadOnly] private int Income;


    private void OnValidate()
    {
        m_Building = GetComponent<Building>();

        if (m_Building != null)
        {
            Income = m_Building.Income;
        }
    }
}
