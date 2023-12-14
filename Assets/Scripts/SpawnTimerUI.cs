using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTimerUI : MonoBehaviour
{
    [SerializeField]
    Image image;

    SpawnTimer spawnTimer;

    void OnEnable()
    {
        spawnTimer = GetComponent<SpawnTimer>();
        spawnTimer.TimeUpdate += ChangeFillAmount;
    }
    void OnDisable()
    {
        spawnTimer.TimeUpdate -= ChangeFillAmount;
    }

    public void ChangeFillAmount(float time, float maxTime)
    {
        image.fillAmount = time / maxTime;
    }
}
