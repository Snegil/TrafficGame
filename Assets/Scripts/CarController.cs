using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CarController : MonoBehaviour
{
    [SerializeField, Header("Maximum amount of cars.")]
    int maxCarAmount;
    [SerializeField]
    int amountToSpawn = 2;
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
    [SerializeField]
    TextMeshProUGUI text;

    [SerializeField]
    bool reverseFill = false;

    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (reverseFill == false)
        {
            clock.fillAmount = timer / setTimer;
            text.text = Mathf.Round(timer).ToString();
        }
        else if (reverseFill == true)
        {
            clock.fillAmount = 1 - (timer / setTimer);
            text.text = "";
        }
        if (timer <= 0)
        {
            if (spawnList.Count < maxCarAmount && reverseFill == false)
            {
                for (int i = 0; i < amountToSpawn; i++)
                {
                    GameObject instantiated = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], carParent);
                    spawnList.Add(instantiated);
                    CarScript carScript = instantiated.GetComponent<CarScript>();
                    carScript.ReferenceCarController(this);
                    carScript.SetRandomSpeed();
                    carScript.SetRoute(routeManager.GetRandomRoute());
                }
                if (setTimer > 0.1f && amountToSpawn != maxCarAmount)
                {
                    amountToSpawn++;
                }
            }
            reverseFill = !reverseFill;
            
            timer = setTimer;
        }
    }
    public void RemoveInList(GameObject gameObject)
    {
       spawnList.Remove(gameObject);
    }
    public float GetSpawnTimer
    {
        get { return timer; }
    }
    public void DestroyAllCars()
    {
        Debug.Log("DESTROY ALL CARS");
        for (int i = 0; i < spawnList.Count - 1; i++)
        {
            Debug.Log("Destroy " + i);
            spawnList[i].GetComponent<CarScript>().SelfDestruct();
        }
        amountToSpawn = 1;
    }
}
