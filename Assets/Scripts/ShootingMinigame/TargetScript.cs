using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public AudioClip snare;
    public AudioSource audiosource;

    //public Animation TargetSpin;
    private Vector3 dir = Vector3.left;
    private Vector3 negdir = Vector3.right;
    public float speed;
    private bool movingLeft;
    public bool Iwashit;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        Iwashit = false;
    }

    // Update is called once per frame


    public void AddScore() {
        audiosource.PlayOneShot(snare);
        animator.SetTrigger("Tapped");
        //TargetSpin.Play();
        Debug.Log("AddScore");
        //rms.score += 1;
        transform.Translate(0,0,-1);
        Iwashit = true;
    }
    public void Reactivate()
    {
        Iwashit = false;
        transform.Translate(0,0,1);
    }

    //Your Update function
void Update(){
     

        if (movingLeft == true) {
        // move left
        transform.Translate(dir*speed*Time.deltaTime);
        if (transform.position.x >= 4) movingLeft = false;
        } else {
        // move right
        transform.Translate(negdir*speed*Time.deltaTime);
        if (transform.position.x <= -4) movingLeft = true;
        }
}
}
