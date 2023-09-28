using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{

    public GameObject choosebotmenu;
    public int botoption; //If option is set to 0, it will say no bot has been chosen

    // Start is called before the first frame update
    void Start()
    {
        botoption = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseOption(int option) {
        //Options: 1 = Male, 2 = Neutral, 3 = Female
        botoption = option;
        Debug.Log("Chose option " + botoption);
    }
}
