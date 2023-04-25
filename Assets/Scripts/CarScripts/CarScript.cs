using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float raycastRange;
    [SerializeField]
    float junctionRange;
    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    List<Transform> firstRoute = new();

    [SerializeField]
    int currentObjective = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, raycastRange, layerMask);
        if (ray.collider == null)
        {
            if (Vector2.Distance(transform.position, firstRoute[0].position) <= junctionRange)
            {
                if (currentObjective != firstRoute.Count)
                {
                    currentObjective++;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, firstRoute[currentObjective].position, speed * Time.deltaTime);
        }
        transform.right = firstRoute[0].position.normalized;
    }
}
