using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarScript : MonoBehaviour
{
    [Space, SerializeField, Header("The objective the car is heading to!")]
    int currentObjective = 0;


    [Space, SerializeField, Header("The tolerance for how close you have to get to the objective.")]
    float objectiveTolerance;

    [Space, SerializeField]
    float speed;

    [SerializeField]
    List<Transform> transformRoute;

    Vector2 directionToObjective;

    bool gettingDestroyed = false;
    public bool GettingDestroyed { set { gettingDestroyed = value; } }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gettingDestroyed == false)
        {
            if (transformRoute == null)
            {
                return;
            }
            if (Vector2.Distance(transformRoute[transformRoute.Count - 1].position, transform.position) <= objectiveTolerance)
            {
                Destroy(gameObject);
            }
            directionToObjective = (transformRoute[currentObjective].position - transform.position).normalized;
            transform.right = directionToObjective;

            if (Vector2.Distance(transform.position, transformRoute[currentObjective].position) <= objectiveTolerance)
            {
                currentObjective++;
            }
            if (currentObjective < transformRoute.Count)
            {
                transform.position = Vector2.MoveTowards(transform.position, transformRoute[currentObjective].position, speed * Time.fixedDeltaTime);
            }
        }        
    }

    public void SetRoute(List<Transform> transformRoute) 
    { 
        this.transformRoute = transformRoute;
        Debug.Log("GOT ROUTE!");       
        currentObjective++;
    }
}
