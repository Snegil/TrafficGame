using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CarStandStill : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Color originalColour;

    Color warningColour = new(255, 0, 0);

    float timer = 2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColour = spriteRenderer.color;
    }
    void FixedUpdate()
    {
        timer -= Time.deltaTime;    
    }
    public void ChangeColour()
    {
        if (timer <= 0)
        {
            if (spriteRenderer.color == originalColour)
            {
                spriteRenderer.color = warningColour;
            }
            else
            {
                spriteRenderer.color = originalColour;
            }
            timer = 2;
        }
    }
    public void ChangeToOriginalColour()
    {
        spriteRenderer.color = originalColour;
    }
}
