using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoboAPTAnimationScript : MonoBehaviour
{

    public Animator Roboanimator;
    public PlayerData playerdata;

    public GameObject NormFace;
    public GameObject BlinkFace;
    public GameObject HappyFace;

    // Start is called before the first frame update
    void Start()
    {
        //Yellow
        // NormFace.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
        //Blue
        // NormFace.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
        //Pink
        //NormFace.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
        NormFace.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        BlinkFace.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        HappyFace.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        switch (playerdata.GetPlayerBot())
        {
            case 3:
                NormFace.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
                BlinkFace.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
                HappyFace.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
                break;
            case 1:
                NormFace.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                BlinkFace.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                HappyFace.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                break;
            case 2:
                NormFace.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                BlinkFace.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                HappyFace.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
                break;
        }
    }

   public void ButtonTapped()
    {
        Roboanimator.SetInteger("AnimIndex", Random.Range(0, 4));
        Roboanimator.SetTrigger("Tapped");
    }
}
