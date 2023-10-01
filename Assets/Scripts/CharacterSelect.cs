using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterSelect : MonoBehaviour
{

    public GameObject choosebotmenu;
    public GameObject chooseoutfitmenu;
    public GameObject choosedatemenu;
    public GameObject choosenamemenu;
    public GameObject confirmscreen;
    public int botoption; //If option is set to 0, it will say no bot has been chosen
    public int outfitoption;
    public int dateoption;
    public string nameoption;
    public TMP_InputField nametext;
    public TextMeshProUGUI botchoicetext;
    public TextMeshProUGUI outfitchoicetext;
    public TextMeshProUGUI datechoicetext;
    public TextMeshProUGUI namechoicetext;
    

    // Start is called before the first frame update
    void Start()
    {
        botoption = 0;
        outfitoption = 0;
        dateoption = 0;
        nameoption = "";

        choosebotmenu.SetActive(true);
        //chooseoutfitmenu.SetActive(false);
        //choosedatemenu.SetActive(false);
    }

    public void ChooseBotOption(int option) {
        //Options: 1 = Male, 2 = Female
        botoption = option;
        choosebotmenu.SetActive(false);
        chooseoutfitmenu.SetActive(true);
        Debug.Log("Chose option " + botoption);
    }

    public void ChooseOutfitOption(int option) {
        outfitoption = option;
        chooseoutfitmenu.SetActive(false);
        choosedatemenu.SetActive(true);
        Debug.Log("Chose outfit " + outfitoption);
    }

    public void ChooseDateOption(int option) {
        //Options: 1 = Cowboy, 2 = Fancy, 3 = Goth
        dateoption = option;
        choosedatemenu.SetActive(false);
        choosenamemenu.SetActive(true);
        Debug.Log("Chose date " + dateoption);
    }

    public void ChooseNameOption() {
        nameoption = nametext.text;
        choosenamemenu.SetActive(false);
        confirmscreen.SetActive(true);
        if (botoption == 1) {
            botchoicetext.text = "Male";
        }
        if (botoption == 2) {
            botchoicetext.text = "Female";
        }
        if (outfitoption == 1) {
            outfitchoicetext.text = "Outfit 1";
        }
        if (outfitoption == 2) {
            outfitchoicetext.text = "Outfit 2";
        }
        if (outfitoption == 3) {
            outfitchoicetext.text = "Outfit 3";
        }
        if (dateoption == 1) {
            datechoicetext.text = "Cowboy";
        }
        if (dateoption == 2) {
            datechoicetext.text = "Fancy";
        }
        if (dateoption == 3) {
            datechoicetext.text = "Goth";
        }
        namechoicetext.text = nameoption;
        Debug.Log("Name chosen as " + nameoption);
    }

    public void Confirm() {
        SceneManager.LoadScene("AptScene");
    }

    public void StartOver() {
        confirmscreen.SetActive(false);
        choosebotmenu.SetActive(true);
        botoption = 0;
        outfitoption = 0;
        dateoption = 0;
        nameoption = "";
    }
}
