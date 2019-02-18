using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Building : MonoBehaviour
{
    

    public Transform door;

    [Expandable]
    public BuildingStats m_buildingStats;

    public List<Pop> Residents;
    public List<Pop> Employees;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Residents = new List<Pop>();
        Employees = new List<Pop>();
    }
    

    public bool TryHire(Pop pop)
    {
        if (HasEmployment() == false)
            return false;

        AddEmployee(pop);
        return true;
    }

    public bool HasVacancy()
    {
        return Residents.Count < m_buildingStats.maxPop;
    }

    public bool HasEmployment()
    {
        return Employees.Count < m_buildingStats.maxJobs;
    }

    private void AddEmployee(Pop pop)
    {
        Employees.Add(pop);
    }
}
