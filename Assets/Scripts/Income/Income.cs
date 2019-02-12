using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Building))]
public class Income : MonoBehaviour
{
    [Expandable]
    public List<IncomeStream> incomeStreams;

    private Building m_building;

    private void Start()
    {
        m_building = GetComponent<Building>();

        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e)
        {
            OnTick();
        };
    }

    void OnTick()
    {
        foreach(IncomeStream incomeStream in incomeStreams)
        {
            if (incomeStream == null) continue;
            incomeStream.GenerateIncome(m_building);
        }
    }
}
