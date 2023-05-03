using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Route
{
    [Space, SerializeField]
    string routeName;

    [SerializeField]
    List<Transform> route = new List<Transform>();

    public Transform GetWaypointAt(int index)
    {
        if (index < 0 || index >= route.Count)
        {
            return null;
        }
        return route[index];
    }
    public int GetNumberOfWaypoints()
    {
        return route.Count;
    }
}
