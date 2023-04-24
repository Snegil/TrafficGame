using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timekeeper : MonoBehaviour
{
    [SerializeField]
    float timer;
    float setTimer;

    [SerializeField]
    Image image;

    private void Start()
    {
        setTimer = timer;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = setTimer;
        }
        timer -= Time.deltaTime;

        image.fillAmount = timer / setTimer;    
    }
}
