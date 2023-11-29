using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOLODAYAnimations : MonoBehaviour
{
    public Animator ChristmasAnimator;
    public bool isHappy;
    public bool isAngry;

    public GameObject AngryChara;
    public GameObject HappyChara;
    // Start is called before the first frame update
    private void Awake()
    {
        if(AngryChara.active)
        {
            isAngry = true;
        }
        if(HappyChara.active)
        {
            isHappy = true;
        }
        if(isHappy)
        {
            GetComponent<Animator>().Play("HappyAnimation");
        }
        if(isAngry)
        {
            GetComponent<Animator>().Play("AngryAnimation");
        }


    }


 }

