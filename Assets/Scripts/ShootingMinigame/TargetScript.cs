using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    [SerializeField] private Animator animator;
    public AudioClip snare;
    public AudioSource audiosource;
    //public Animation TargetSpin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore() {
        audiosource.PlayOneShot(snare);
        animator.SetTrigger("Tapped");
        //TargetSpin.Play();
        Debug.Log("AddScore");
        //rms.score += 1;
    }
}
