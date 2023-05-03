using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{
    [SerializeField]
    List<Route> routes = new List<Route>();

    public Route GetRandomRoute()
    {
        return routes[Random.Range(0, routes.Count)];
    }
}
