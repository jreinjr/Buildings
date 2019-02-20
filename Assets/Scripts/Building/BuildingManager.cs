using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingManager : MonoBehaviour
{
    // Singleton instance
    public static BuildingManager instance = null;

    public class OnBuildingBuiltEventArgs : EventArgs
    {
        public Building building;
    }
    public static event EventHandler<OnBuildingBuiltEventArgs> OnBuildingBuilt;

    public List<Building> Buildings { get; protected set; }

    private void Awake()
    {
        // Singleton behavior
        if (instance == null) instance = this;
        else if (instance != this) DestroyImmediate(gameObject);
    }

    private void Start()
    {
        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e) { OnTick(); };

        Buildings = new List<Building>();
    }

    public void SpawnBuilding(Building buildingType)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int mask = LayerMask.NameToLayer("Buildings");
        //if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, mask, QueryTriggerInteraction.UseGlobal))
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, mask))
        {
            Debug.Log(hitInfo.collider.name);
            Transform newBuildingTransform = Instantiate(buildingType.transform);
            Building newBuilding = newBuildingTransform.GetComponent<Building>();
            newBuildingTransform.position = hitInfo.point;
            Buildings.Add(newBuilding);
            //newBuilding.Place();

        }
    }

    public void DestroyAllBuildings()
    {
        foreach (Building b in Buildings)
        {
            DestroyImmediate(b.gameObject);
        }
        Buildings = new List<Building>();
    }

    void OnTick()
    {
        
    }
}
