using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CarController : MonoBehaviour
{
    [SerializeField, Header("Maximum amount of cars.")]
    int maxCarAmount;

    [Space, SerializeField, Header("Spawn Timer.")]
    float timer;
    float setTimer;
    [SerializeField]
    RouteManager routeManager;
    [SerializeField]
    ScoreKeeper scoreKeeper;
    [SerializeField]
    Transform carParent;

    [Space, SerializeField, Header("Car Prefabs")]
    GameObject[] spawnObjects = new GameObject[3];

    List<GameObject> spawnList = new List<GameObject>();

    [Space, SerializeField, Header("Countdown to spawn.")]
    Image clock;

    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        clock.fillAmount = timer / setTimer;
        if (timer <= 0)
        {
            if (spawnList.Count < maxCarAmount)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject instantiated = Instantiate(spawnObjects[i], carParent);
                    spawnList.Add(instantiated);
                    CarScript carScript = instantiated.GetComponent<CarScript>();
                    carScript.ReferenceCarController(this);
                    carScript.SetRandomSpeed();
                    carScript.SetRoute(routeManager.GetRandomRoute());
                }
            }
            timer = setTimer;
        }
    }
    public void RemoveInList(GameObject gameObject)
    {
       spawnList.Remove(gameObject);
    }
}
