using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StreetNameManager : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    Camera cam;

    [SerializeField]
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.value;

        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(mousePosition);

        Collider2D[] roads = Physics2D.OverlapPointAll(mouseWorldPos, layerMask);
        
        text.text = " ";
        if (roads != null)
        {
            if (roads.Length == 1)
            {
                text.text = roads[0].name;
            }
            if (roads.Length == 2)
            {
                text.text = "Korsningen av " + roads[0].name + " and " + roads[1].name;
            }
        }
    }
}
