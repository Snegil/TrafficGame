using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelfDestruct : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    NewCarScript carScript;

    [SerializeField]
    float timeUntilDestruction;

    public void DestroyEveryCar()
    {
        spriteRenderer.color = Color.white;
        carScript.GettingDestroyed = true;
        animator.SetBool("SelfDestruct", true);
        DestroyThis();
    }
    public void DestroyThis()
    {
        Destroy(gameObject, timeUntilDestruction);
    }
}
