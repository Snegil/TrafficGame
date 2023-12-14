using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateDestruct : MonoBehaviour
{
    [SerializeField]
    GameObject carParent;

    [SerializeField]
    float timeUntilDestruction;
    public void InitiateDestructSequence()
    {
        for (int i = 0; i < carParent.transform.childCount; i++)
        {
            carParent.transform.GetChild(i).GetComponent<CarSelfDestruct>().DestroyEveryCar();
        }
    }
}
