using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CarStandStill : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    Color originalColour;

    Color warningColour = new(255, 0, 0);

    float timer = 0.25f;
    float setTimer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColour = spriteRenderer.color;
        setTimer = timer;
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
            timer = setTimer;
        }
    }
    public void ChangeToOriginalColour()
    {
        spriteRenderer.color = originalColour;
    }
}
