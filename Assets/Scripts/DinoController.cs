using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DinoController : MonoBehaviour
{
    public InputActionAsset inputs;
    public TextMeshProUGUI score;
    private InputAction tap;
    private Rigidbody2D rb;
    private bool tapped;
    public float force;
    private bool grounded;
    public float speedScale;
    private float currentScore;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tap = inputs.FindAction("Player/MouseButton");
        tapped = false;
        grounded = false;
        currentScore = 1;
        score.text = "Distance: " + currentScore + "m";
    }

    void OnEnable() {
        inputs.Enable();
    }
    void OnDisable() {
        inputs.Disable();
    }

    private void Update()
    {
        tapped = tap.WasPerformedThisFrame();

        if (tapped && grounded) {
            Jump();
        }

        AddScore(1);
    }

    void AddScore(int newscore) {
        currentScore += newscore;
        score.text = "Distance: " + currentScore + "m";
        
    }

    void Jump() {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        grounded = false;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            grounded = true;
        }
    }
    
}
