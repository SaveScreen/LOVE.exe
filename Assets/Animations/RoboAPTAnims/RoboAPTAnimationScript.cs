using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboAPTAnimationScript : MonoBehaviour
{

    public Animator Roboanimator;
    // Start is called before the first frame update
    void Start()
    {

    }

   public void ButtonTapped()
    {
        Roboanimator.SetInteger("AnimIndex", Random.Range(0, 4));
        Roboanimator.SetTrigger("Tapped");
    }
}
