using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CircleScript : MonoBehaviour
{
    public float rate;
    public float speed;
    private SpriteRenderer sprrender;
    private float c;
    private GameObject minigamemaster;
    private RhythmMinigameScript rms;
    public bool clicked;
    public AudioClip snare;
    public InputAction click;
    private Camera maincamera;

    // Start is called before the first frame update
    void Start()
    {
        minigamemaster = GameObject.FindWithTag("Rhythmgame");
        maincamera = FindObjectOfType<Camera>();
        rms = minigamemaster.GetComponent<RhythmMinigameScript>();
        sprrender = GetComponent<SpriteRenderer>();
        

        c = 1;
    }
    
    void OnEnable() {
        click.Enable();
    }
    void OnDisable() {
        click.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (c > 0f) {
            c = Mathf.Lerp(1,0,rate);
            sprrender.color = new Color(1,c,c,1);
            rate += speed * Time.deltaTime;
            //Debug.Log(speed);
            //Debug.Log(c);
        }
        else {
            Destroy(gameObject);
        }

        if (click.WasPressedThisFrame()) {
            var rayHit = Physics2D.GetRayIntersection(maincamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
            if (!rayHit.collider) return;

            //Debug.Log(rayHit.collider.gameObject.name);
            AddScore();
        }
        
    }
    
    public void AddScore() {
        rms.PlaySound(snare);
        rms.score += 1;
        Destroy(gameObject);
    }

    

}
