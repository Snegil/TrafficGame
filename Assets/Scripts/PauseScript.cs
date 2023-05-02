using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    bool paused = false;

    [SerializeField]
    Sprite pausedSprite;
    [SerializeField]
    Sprite playingSprite;

    Image image;

    [Space, SerializeField, Header("paused UI Selection")]
    GameObject uiSelection;

    [Space, SerializeField, Header("resumed UI Selection")]
    GameObject resumedUiSelection;
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
            EventSystem.current.SetSelectedGameObject(uiSelection);
        }
        else
        {
            Time.timeScale = 1.0f;
            image.sprite = pausedSprite;
            EventSystem.current.SetSelectedGameObject(resumedUiSelection);
        }
        
    }
}
