using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{ 
    Vector3 _waypoint;
    float _duration;

    public Task(Vector3 waypoint, float duration)
    {
        _waypoint = waypoint;
        _duration = duration;
    }
}
