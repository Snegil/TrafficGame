using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCarColour : MonoBehaviour
{

    [SerializeField]
    List<Color> colors = new List<Color>();

    Color myColour;

    // Start is called before the first frame update
    void Start()
    {
        myColour = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        ChangeColour();   
    }
    
    void ChangeColour()
    {
        GetComponent<SpriteRenderer>().color = myColour;

        //GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)];
    }
}
