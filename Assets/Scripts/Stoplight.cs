using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stoplight : MonoBehaviour
{
    [SerializeField]
    bool westEast = true;
    [SerializeField]
    bool northSouth = false;

    [Space, SerializeField, Header("North West Colliders")]
    Collider2D northWestTop;
    [SerializeField]
    Collider2D northWestLeft;

    [Space, SerializeField, Header("South West Colliders")]
    Collider2D southWestBottom;
    [SerializeField]
    Collider2D southWestLeft;

    [Space, SerializeField, Header("North East Colliders")]
    Collider2D northEastTop;
    [SerializeField]
    Collider2D northEastRight;

    [Space, SerializeField, Header("South East Colliders")]
    Collider2D southEastBottom;
    [SerializeField]
    Collider2D southEastRight;

    [Space, SerializeField, Header("Stoplight Sprites")]
    Sprite ewGreen;
    [SerializeField]
    Sprite nsGreen;

    Image image;

    [Space, SerializeField, Header("Sound Effect")]
    AudioClip clip;

    AudioSource audioSrc;
    private void Start()
    {
        image = GetComponent<Image>();
        audioSrc = GetComponent<AudioSource>();
    }
    public void FlipStopLight()
    {
        audioSrc.pitch = Random.Range(0.95f, 1.05f);
        audioSrc.PlayOneShot(clip);

        westEast = !westEast;
        northSouth = !northSouth;
        if (westEast == true)
        {
            //transform.Rotate(0, 0, 90);

            image.sprite = ewGreen;

            northWestTop.enabled = true;
            southEastBottom.enabled = true;

            northWestLeft.enabled = false;
            southEastRight.enabled = false;
            northEastRight.enabled = false;
            northEastTop.enabled = false;
            southWestLeft.enabled = false;
            southWestBottom.enabled = false;
        }
        if (northSouth == true)
        {
            //transform.Rotate(0, 0, -90);

            image.sprite = nsGreen;

            northEastRight.enabled = true;
            southWestLeft.enabled = true;

            northEastTop.enabled = false;
            southWestBottom.enabled = false;
            northWestLeft.enabled = false;
            northWestTop.enabled = false;
            southEastRight.enabled = false;
            southEastBottom.enabled = false;
        }
        Debug.Log("FlipStopLight()");
        Debug.Log("\n" + "FlipStopLight() \n" + "West, East: " + westEast + "\n" + "North South: " + northSouth);
    }
}
