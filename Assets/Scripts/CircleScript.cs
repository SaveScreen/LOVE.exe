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
    public AudioClip snare;
    public InputActionAsset inputs;
    private InputAction click;
    private InputAction pos;
    private Camera maincamera;
    public bool gameover;
    private bool clicked;
    private Vector2 mousepos;
    //private bool isOnMobile;

    public GameObject Child;
    public float growFactor;
    public GameObject self;
    

    // Start is called before the first frame update
    void Start()
    {
        minigamemaster = GameObject.FindWithTag("Rhythmgame");
        maincamera = FindObjectOfType<Camera>();
        rms = minigamemaster.GetComponent<RhythmMinigameScript>();
        sprrender = GetComponent<SpriteRenderer>();
        
        c = 1;
        gameover = false;
        click = inputs.FindAction("Player/MouseButton");
        pos = inputs.FindAction("Player/MousePosition");

    }
    
    void OnEnable() {
        inputs.Enable();
    }
    void OnDisable() {
        inputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = pos.ReadValue<Vector2>();
        clicked = click.WasPerformedThisFrame();

        if (!gameover) {
            if (c > 0f) {
            c = Mathf.Lerp(1,0,rate);
                //sprrender.color = new Color(1,c,c,1);
                rate += speed * Time.deltaTime;
                Child.transform.localScale += new Vector3(.1f, .1f, 0) * growFactor * Time.deltaTime;
            }
            else {
                Destroy(gameObject);
                rms.GameOver();
            }

            
        } 
        else {
            if (rms.restart == true) {
                Destroy(gameObject);
            }
        }
          
        gameover = rms.gameover;
    }
    
    public void AddScore() {
        rms.PlaySound(snare);
        rms.score += 1;
        Destroy(self);
    }
    
}
