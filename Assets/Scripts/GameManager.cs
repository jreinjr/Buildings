using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance = null;

    public static Inventory Inventory;

    
    
    private void Awake()
    {
        // Singleton behavior
        if (instance == null) instance = this;
        else if (instance != this) DestroyImmediate(gameObject);

        Inventory = GetComponent<Inventory>();
    }

    private void Start()
    {
        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e)
        {
            OnTick();
        };
    }

    public void SpawnBuilding(Building buildingType)
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            Transform newBuilding = Instantiate(buildingType.transform);
            newBuilding.position = hitInfo.point;
        }
    }

    void OnTick()
    {
       // inventory.UpdateInventoryText();
    }

}
