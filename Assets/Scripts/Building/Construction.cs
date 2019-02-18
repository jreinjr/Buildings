using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ConstructionStatus
{
    Placement,
    Construction,
    Complete
}
public class Construction : MonoBehaviour
{
    
    public class OnConstructionStatusChangedEventArgs : EventArgs
    {
        public Building building;
        public ConstructionStatus status;
    }
    public static event EventHandler<OnConstructionStatusChangedEventArgs> OnConstructionStatusChanged;

    public GameObject placement_mesh;
    public GameObject construction_mesh;
    public GameObject complete_mesh;

    private ConstructionStatus currentStatus;

    private void Start()
    {

    }

    public bool Place()
    {
        currentStatus = ConstructionStatus.Placement;
        UpdateMesh();
        return false;
    }

    public ConstructionStatus GetStatus()
    {
        return currentStatus;
    }

    private void UpdateMesh()
    {
        switch (currentStatus)
        {
            case ConstructionStatus.Placement:
                placement_mesh.SetActive(true);
                construction_mesh.SetActive(false);
                complete_mesh.SetActive(false);
                break;
            case ConstructionStatus.Construction:
                placement_mesh.SetActive(false);
                construction_mesh.SetActive(true);
                complete_mesh.SetActive(false);
                break;
            case ConstructionStatus.Complete:
                placement_mesh.SetActive(false);
                construction_mesh.SetActive(false);
                complete_mesh.SetActive(true);
                break;
            default:
                break;
        }
    }
}
