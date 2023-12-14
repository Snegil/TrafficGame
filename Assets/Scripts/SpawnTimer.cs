using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    public delegate void TimeHitZeroEvent();
    public delegate void TimeUpdated(float time, float maxTime);
    public event TimeUpdated TimeUpdate;
    public event TimeHitZeroEvent TimeHitZero;

    [Space, SerializeField]
    float timer;
    float setTimer;

    // Start is called before the first frame update
    void Start()
    {
        setTimer = timer;    
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        TimeUpdate?.Invoke(timer, setTimer);
        if (timer <= 0)
        {
            TimeHitZero?.Invoke();
            timer = setTimer;
            TimeUpdate?.Invoke(timer, setTimer);
        }
    }
}
