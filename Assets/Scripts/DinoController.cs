using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoController : MonoBehaviour
{
    private dinoController dino;
    private Vector3 movement;

    public float gravity = 9.81f;

    private void Awake()
    {
        dino = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        movement = Vector3.zero;
    }

    private void Update()
    {

    }

}
