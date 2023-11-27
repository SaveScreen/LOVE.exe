using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DinoController : MonoBehaviour
{
    public InputActionAsset inputs;
    private InputAction tap;
    private Rigidbody rb;
    private bool tapping;

    public float gravity = 9.81f;

    private void Start()
    {

        tapping = false;
    }

    private void Update()
    {

    }
    
}
