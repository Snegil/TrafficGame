using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float raycastRange;
    [SerializeField]
    float junctionRange;
    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    List<Transform> route = new();

    [SerializeField]
    int currentObjective = 0;
    Vector2 directionToObjective;

    int randomRoute;
    // Start is called before the first frame update
    void Start()
    {
        randomRoute = Random.Range(0, 1); //IF ROUTE == 0 = FIRST ROUTE, IF ROUTE == 1 = SECOND ROUTE
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, raycastRange, layerMask);
        Debug.DrawRay(transform.position, transform.right * raycastRange, Color.green);

        CheckIfInRangeToJunction();
        if (randomRoute == 0)
        {
            directionToObjective = (route[currentObjective].position - transform.position).normalized;

            transform.right = directionToObjective;
            if (ray.collider == null)
            {
                transform.position = Vector2.MoveTowards(transform.position, route[currentObjective].position, speed * Time.deltaTime);
            }
        }
    }
    void CheckIfInRangeToJunction()
    {
        if (randomRoute == 0)
        {
            if (Vector2.Distance(transform.position, route[currentObjective].position) <= junctionRange)
            {
                if (currentObjective == route.Count - 1)
                {
                    Destroy(gameObject);
                }
                if (currentObjective != route.Count - 1)
                {
                    currentObjective++;
                }
            }
        }
    }
    public void AddToRouteList(List<Transform> waypoints)
    {
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            route.Add(waypoints[i]);
        }
    }
}

 // || Vector2.Distance(transform.position, secondRoute[currentObjective].position) <= junctionRange
