using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Space, SerializeField, Header("Spawn Timer.")]
    float timer;
    float setTimer;
    [SerializeField]
    RouteManager routeManager;

    [Space, SerializeField, Header("Car Prefabs")]
    GameObject[] spawnObjects = new GameObject[3];

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
                GameObject instantiated = Instantiate(spawnObjects[i]);
                CarScript carScript = instantiated.GetComponent<CarScript>();
                carScript.SetRandomSpeed();
                carScript.SetRoute(routeManager.GetRandomRoute());
            }
        }
    }
}
