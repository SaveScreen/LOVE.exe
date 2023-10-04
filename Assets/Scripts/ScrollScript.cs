using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ScrollScript : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputs;
    public GameObject outfits; //Put only the Choose Outfit game object here
    private InputAction mouse;
    private InputAction click;
    private InputAction hold;
    private bool clicked;
    private bool holding;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        click = inputs.FindAction("Player/MouseButton");
        hold = inputs.FindAction("Player/TouchHold");
        mouse = inputs.FindAction("Player/Mouse");
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        clicked = click.WasPressedThisFrame();
        holding = hold.IsPressed();
        if (holding)
        {
            mousePosition = mouse.ReadValue<Vector2>();
        }
        
        
    }
}
