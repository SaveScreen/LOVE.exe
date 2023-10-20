using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public GameObject circle;
    private Camera maincamera;
    public void ClickCircles(InputAction.CallbackContext context) {
        CircleScript circleScript = circle.GetComponent<CircleScript>();
        
        if (!context.started) return;

        
    }
}
