using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueID : MonoBehaviour
{
    public enum ID_Prefix
    {
        BLDG,
        POP
    }
    public ID_Prefix prefix;

    public static int nextID = 0;
    public string ID { get { return GetID(); } }
    [ReadOnly][SerializeField]
    private int _ID;

    private void Awake()
    {
        _ID = nextID;
        nextID++;
    }

    private string GetID()
    {
        return prefix + "_" + _ID;
    }
}
