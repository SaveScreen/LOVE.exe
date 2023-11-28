using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private GameObject minigamemaster;
    private ShootingMinigameControler SMC;

    private Vector3 spawnpos;
    public Vector3 uprightpos;
    public Vector3 currentpos;

    [SerializeField] private Animator animator;
    public AudioClip snare;
    public AudioSource audiosource;

    //public Animation TargetSpin;
    private Vector3 dir = Vector3.forward;
    private Vector3 negdir = -Vector3.forward;
    public float speed;
    public float ismovingspeed;
    private float velocity;
    public bool movingLeft;
    public bool Iwashit;
    [Header("types of targets")]
    public bool movingtarget;
    public bool ismoving;

    public int scoreValue;

    public float TimeUp;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        ismoving = false;
        Iwashit = false;
        spawnpos = transform.position;
        minigamemaster = GameObject.FindWithTag("Rhythmgame");
        SMC = minigamemaster.GetComponent<ShootingMinigameControler>();
    }

    // Update is called once per frame
    //Your Update function
void Update(){

        currentpos = transform.position;
        if(movingtarget && ismoving)
        {
            if (movingLeft == true)
            {
                // move left
                transform.Translate(dir * ismovingspeed * Time.deltaTime);
                if (transform.position.x >= 5) movingLeft = false;
            }
            else
            {
                // move right
                transform.Translate(negdir * ismovingspeed * Time.deltaTime);
                if (transform.position.x <= -5) movingLeft = true;
            }
        }

        
        if (Input.GetKeyDown(KeyCode.W))
        {
            InitializeTargets();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ResetTargets();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            flipuptargets();
        }
    }

    public void AddScore()
    {
        audiosource.PlayOneShot(snare);
        //animator.SetTrigger("Tapped");
        //TargetSpin.Play();
        Debug.Log("AddScore");
        SMC.score += scoreValue;
        transform.Translate(0, 0, -1);
        Iwashit = true;
        ismoving = false;
        transform.position = spawnpos;
    }
    public void ResetTargets()
    {
        Iwashit = false;
        ismoving = false;
        transform.position = spawnpos;
    }

    public void InitializeTargets()
    {
        Debug.Log("targets initialized");
        if (!movingtarget)
        {
            transform.position = uprightpos;
        }
        
        ismoving = !ismoving;

        StartCoroutine(TimerTillDown());
    }
    public void flipuptargets()
    {
        transform.position = uprightpos;
    }

    public IEnumerator TimerTillDown()
    {
        yield return new WaitForSeconds(TimeUp);
        ResetTargets();

    }
}
