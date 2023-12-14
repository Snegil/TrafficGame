using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    public void DestroyThisObjectsParent()
    {
        Debug.Log("Destroy Parent");
        Destroy(gameObject.transform.parent.gameObject);
        //transform.parent.GetComponent<CarSelfDestruct>().DestroyThis();
    }
}
