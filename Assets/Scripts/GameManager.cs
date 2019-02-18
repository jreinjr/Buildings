using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance = null;

    public static Inventory Inventory;
    
    public List<Pop> AllPops { get; protected set; }
    public List<Building> AllBuildings { get; protected set; }
    
    private void Awake()
    {
        // Singleton behavior
        if (instance == null) instance = this;
        else if (instance != this) DestroyImmediate(gameObject);

        Inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e){  OnTick();   };
    }

    public void SpawnBuilding(Building buildingType)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int mask = LayerMask.NameToLayer("Buildings");
        //if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, mask, QueryTriggerInteraction.UseGlobal))
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, mask))
        {
            Debug.Log(hitInfo.collider.name);
            Transform newBuilding = Instantiate(buildingType.transform);
            newBuilding.position = hitInfo.point;
            //newBuilding.Place();
        }
    }

    void OnTick()
    {
       // inventory.UpdateInventoryText();
    }

}
