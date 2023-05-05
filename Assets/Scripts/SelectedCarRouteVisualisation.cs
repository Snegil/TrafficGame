using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectedCarRouteVisualisation : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField]
    float removeLineTimer;
    float setRemoveLineTimer;

    [SerializeField]
    LayerMask carMask;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        removeLineTimer = setRemoveLineTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.value;

        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(mousePosition);

        Collider2D carCollider = Physics2D.OverlapPoint(mouseWorldPos, carMask);

        if (carCollider != null)
        {
            lineRenderer.enabled = true;
            List<Vector3> waypoints = carCollider.gameObject.GetComponent<CarScript>().GetRemainingWaypoints();

            lineRenderer.positionCount = waypoints.Count;
            lineRenderer.SetPositions(waypoints.ToArray());   
        }
        if (carCollider == null)
        {
            removeLineTimer -= Time.deltaTime;
            if (removeLineTimer <= 0)
            {
                removeLineTimer = setRemoveLineTimer;
                lineRenderer.enabled = false;
            }
        }
    }
}
