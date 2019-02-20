using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Building))]
public class Populate : MonoBehaviour
{
    public class OnPopSpawnEventArgs : EventArgs
    {
        public Pop pop;
    }
    public static event EventHandler<OnPopSpawnEventArgs> OnPopSpawn;

    private Building m_building;

    private void Start()
    {
        m_building = GetComponent<Building>();

        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e)
        {
            OnTick();
        };

        SpawnPop();
    }


    private void SpawnPop()
    {
        if (m_building.HasVacancy() == false)
        {
            return;
        }

        GameObject newGameObject = Instantiate(Resources.Load("Prefabs/Pop")) as GameObject;
        Pop newPop = newGameObject.GetComponent<Pop>();
        newGameObject.transform.position = m_building.door.position;
        newPop.SetHome(m_building);
        m_building.Residents.Add(newPop);

        OnPopSpawn?.Invoke(this, new OnPopSpawnEventArgs{ pop = newPop });
    }


    private void OnTick()
    {
        if (m_building.HasVacancy())
            SpawnPop();
    }
}
