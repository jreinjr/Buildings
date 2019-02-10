using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance = null;

    public int Gold
    {
        get
        {
            return _gold;
        }
    }
    [ReadOnly] [SerializeField] private int _gold;
    
    private void Awake()
    {
        // Singleton behavior
        if (instance == null) instance = this;
        else if (instance != this) DestroyImmediate(gameObject);
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

    }

    void CollectIncome()
    {

    }
}
