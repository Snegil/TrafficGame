using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarController : MonoBehaviour
{
    [Space, SerializeField, Header("A* MANAGER,")]
    AStarManager aStarManager;

    [SerializeField, Header("A* start and end nodes!")]
    List<AStarNode> startAndEndNodes = new List<AStarNode>();

    [Space, SerializeField]
    SpawnTimer spawnTimer;

    [Space, SerializeField, Header("Car prefab;")] 
    GameObject car;

    [Space, SerializeField, Header("Car parent;")]
    Transform carParent;

    [Space, SerializeField, Header("Max amount of cars;")]
    float maxCars;

    void OnEnable()
    {
        spawnTimer.TimeHitZero += SpawnCar;
    }
    void OnDisable()
    {
        spawnTimer.TimeHitZero -= SpawnCar;
    }
    
    public void SpawnCar()
    {
        int randomnumber = Random.Range(0, startAndEndNodes.Count);
        int randomnumbertwo = Random.Range(0, startAndEndNodes.Count);

        while (randomnumbertwo == randomnumber)
        {
            randomnumbertwo = Random.Range(0, startAndEndNodes.Count);
        }

        List<Transform> route = new List<Transform>();
        route = aStarManager.CalculateRoute(startAndEndNodes[randomnumber], startAndEndNodes[randomnumbertwo]);

        Debug.Log("SPAWN CAR");

        GameObject instantiated = Instantiate(car, route[0].position, Quaternion.identity, carParent);
        
        instantiated.GetComponent<NewCarScript>().SetRoute(route);
        Debug.Log("instantiated " + instantiated.name);        
    }
    int GetChildrenInCarParent()
    {      
        return 100;
    }
}
