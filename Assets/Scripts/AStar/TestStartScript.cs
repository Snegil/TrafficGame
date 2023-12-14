using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStartScript : MonoBehaviour
{
    [SerializeField]
    AStarNode startNode;
    [SerializeField]
    AStarNode endNode;
    [SerializeField]
    AStarManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager.CalculateRoute(startNode, endNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
