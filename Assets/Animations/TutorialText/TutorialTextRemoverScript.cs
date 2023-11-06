using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextRemoverScript : MonoBehaviour
{
    public GameObject TutText;
    public Animator TutAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        TutAnimator.Play("TextRemover");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
