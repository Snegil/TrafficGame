using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Space, SerializeField, Header("Spawn Timer.")]
    float timer;
    float setTimer;

    [Space, SerializeField, Header("Spawn position.")]
    Transform[] spawnPoints = new Transform[3]; // 0 == RED; 1 == GREEN; 2 == BLUE

    [Space, SerializeField, Header("Car Prefabs")]
    GameObject[] spawnObjects = new GameObject[3];

    [Space, SerializeField, Header("Red car routes.")]
    List<Transform> redRouteOne = new List<Transform>();
    [SerializeField]
    List<Transform> redRouteTwo = new List<Transform>();

    [Space, SerializeField, Header("Green car routes.")]
    List<Transform> greenRouteOne = new List<Transform>();
    [SerializeField]
    List<Transform> greenRouteTwo = new List<Transform>();

    [Space, SerializeField, Header("Blue car routes.")]
    List<Transform> blueRouteOne = new List<Transform>();
    [SerializeField]
    List<Transform> blueRouteTwo = new List<Transform>();

    int routeIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = setTimer;
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(i);
                Debug.Log(routeIndex);
                GameObject instantiated = Instantiate(spawnObjects[i], spawnPoints[i].position, Quaternion.identity);
                instantiated.GetComponent<CarScript>().RandomSpeed();
                if (i == 0) //RED
                {
                    Debug.Log("Red");
                    if (routeIndex == 0)
                    {
                        instantiated.GetComponent<CarScript>().AddToRouteList(redRouteOne);
                    }
                    if (routeIndex == 1)
                    {
                        instantiated.GetComponent<CarScript>().AddToRouteList(redRouteTwo);
                    }
                }
                if (i == 1) //GREEN
                {
                    Debug.Log("Green");
                    if (routeIndex == 0)
                    {
                        instantiated.GetComponent<CarScript>().AddToRouteList(greenRouteOne);
                    }
                    if (routeIndex == 1)
                    {
                        instantiated.GetComponent<CarScript>().AddToRouteList(greenRouteTwo);
                    }
                }
                if (i == 2) //BLUE
                {
                    Debug.Log("Blue");
                    if (routeIndex == 0)
                    {
                        instantiated.GetComponent<CarScript>().AddToRouteList(blueRouteOne);
                    }
                    if (routeIndex == 1)
                    {
                        instantiated.GetComponent<CarScript>().AddToRouteList(blueRouteTwo);
                    }
                }
            }
            routeIndex++;
            if (routeIndex > 1)
            {
                routeIndex = 0;
            }
            Debug.Log("Route Index: " + routeIndex);
        }
    }
}
