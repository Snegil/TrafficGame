using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseWithControls : MonoBehaviour
{
    PauseScript pauseScript;
    // Start is called before the first frame update
    void Start()
    {
        pauseScript = GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGameWithControls(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            pauseScript.PauseGame();
        }
    }
}
