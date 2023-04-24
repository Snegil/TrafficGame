using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    bool paused = false;

    [SerializeField]
    Sprite pausedSprite;
    [SerializeField]
    Sprite playingSprite;

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        paused = !paused;
        if (paused == true)
        {
            Time.timeScale = 0.0f;
            image.sprite = playingSprite;
        }
        else
        {
            Time.timeScale = 1.0f;
            image.sprite = pausedSprite;
        }
        
    }
}
