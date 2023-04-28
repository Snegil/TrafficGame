using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    float speed;

    [SerializeField]
    float minSpeed;
    [SerializeField]
    float maxSpeed;

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

    Transform child;
    // Start is called before the first frame update
    void Start()
    {
        child = gameObject.transform.GetChild(0).gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(child.position, transform.right, raycastRange, layerMask);
        Debug.DrawRay(transform.position, transform.right * raycastRange, Color.green);

        CheckIfInRangeToJunction();
        directionToObjective = (route[currentObjective].position - transform.position).normalized;

        transform.right = directionToObjective;
        if (ray.collider == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, route[currentObjective].position, speed * Time.deltaTime);
        }
    }
    void CheckIfInRangeToJunction()
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
    public void AddToRouteList(List<Transform> waypoints)
    {
        route = waypoints;
    }
    public void RandomSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
}
