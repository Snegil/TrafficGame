using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeed : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites = new Sprite[4];

    Image image;

    int index;

    void Start()
    {
        image = GetComponent<Image>();         
    }
    public void ChangeTime()
    {
        if (index == sprites.Length)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        ChangeImage(index);
    }
    void ChangeImage(int index)
    {
        image.sprite = sprites[index];
    }
}
