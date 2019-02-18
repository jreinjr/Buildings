using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBake : MonoBehaviour
{
    public NavMeshSurface surface;

    private void Start()
    {
        if (surface == null)
            surface = GetComponent<NavMeshSurface>();

        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e) { OnTick(); };
    }

    void OnTick()
    {

    }

    public void Bake()
    {
        surface.BuildNavMesh();
    }
}
