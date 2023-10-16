using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Animator animator;
    public bool animating;

    void Start() {
        animator = GetComponent<Animator>();
        animating = false;
    }

    void Update() {
        
    }

    public void BallAnimation(int animstate) {
        animator.SetInteger("State",animstate);
        animating = true;
    }
}
