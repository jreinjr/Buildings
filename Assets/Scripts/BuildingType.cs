using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "Buildings/BuildingType", order = 1)]
public class BuildingType : ScriptableObject
{
    public string description;
    public char hotkey;
}
