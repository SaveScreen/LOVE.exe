using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryHappyAnimScript : MonoBehaviour
{
    public Animator AngryAnimator;
    public Animator HappyAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Animator>().Play("AngryAnimation");
        GetComponent<Animator>().Play("HappyAnimation");
    }
}
