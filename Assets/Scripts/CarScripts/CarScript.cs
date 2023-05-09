using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    float score;

    [SerializeField]
    float startTimer;
    float setStartTimer;

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

    Route route;

    [SerializeField]
    int currentObjective = 0;
    Vector2 directionToObjective;

    Transform firstChild;
    Transform secondChild;
    CarController controller;

    // Start is called before the first frame update
    void Start()
    {
        firstChild = gameObject.transform.GetChild(0).gameObject.transform;
        secondChild = gameObject.transform.GetChild(1).gameObject.transform;
        setStartTimer = startTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D rayOne = Physics2D.Raycast(firstChild.position, transform.right, raycastRange, layerMask);
        RaycastHit2D rayTwo = Physics2D.Raycast(secondChild.position, transform.right, raycastRange, layerMask);

        Debug.DrawRay(firstChild.position, transform.right * raycastRange, Color.green);
        Debug.DrawRay(secondChild.position, transform.right * raycastRange, Color.green);

        CheckIfInRangeToJunction();
        directionToObjective = (route.GetWaypointAt(currentObjective).position - transform.position).normalized;

        transform.right = directionToObjective;

        if (rayOne.collider == null && rayTwo.collider == null)
        {
            startTimer -= Time.deltaTime;
            if (startTimer <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, route.GetWaypointAt(currentObjective).position, speed * Time.fixedDeltaTime);
            }
        }

        if (rayOne.collider != null && rayTwo.collider != null)
        {
            startTimer = setStartTimer;
        }
    }
    void CheckIfInRangeToJunction()
    {
        if (Vector2.Distance(transform.position, route.GetWaypointAt(currentObjective).position) <= junctionRange)
        {
            transform.position = route.GetWaypointAt(currentObjective).position;
            if (currentObjective == route.GetNumberOfWaypoints() - 1)
            {
                controller.RemoveInList(gameObject);
                Destroy(gameObject);
            }
            if (currentObjective != route.GetNumberOfWaypoints() - 1)
            {
                currentObjective++;
            }
        }
    }
    public void SetRoute(Route route)
    {
        this.route = route;
        transform.position = route.GetWaypointAt(0).position;
        currentObjective = 1;
    }
    public void SetRandomSpeed()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
    public List<Vector3> GetRemainingWaypoints()
    {
        List<Vector3> waypoints = new List<Vector3>();
        waypoints.Add(transform.position);
        for (int i = currentObjective; i < route.GetNumberOfWaypoints(); i++)
        {
            waypoints.Add(route.GetWaypointAt(i).position);
        }
        return waypoints;
    }
    public void ReferenceCarController(CarController controller)
    {
        this.controller = controller;
    }
}
