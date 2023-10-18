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
    public GameObject playergamescreen;
    public int botoption; //If option is set to 0, it will say no bot has been chosen
    public int outfitoption;
    public int dateoption;
    public string nameoption;
    public TMP_InputField nametext;
    public TextMeshProUGUI botchoicetext;
    public TextMeshProUGUI outfitchoicetext;
    public TextMeshProUGUI datechoicetext;
    public TextMeshProUGUI namechoicetext;
    public GameObject playerdatacontainer;
    public PlayerData playerdata;

    public GameObject leftArrow;
    public GameObject rightArrow;


    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        botoption = 0;
        outfitoption = 0;
        dateoption = 0;
        nameoption = "";

        if (PlayerData.playerbot == 0 && PlayerData.playerdate == 0 && PlayerData.playeroutfit == 0 && PlayerData.playername == "") {
            choosebotmenu.SetActive(true);
            //chooseoutfitmenu.SetActive(false);
            //choosedatemenu.SetActive(false);
            //choosenamemenu.SetActive(false);
        }
        else {
            playergamescreen.SetActive(true);
        }
         
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
            Debug.Log("Quit");
        }
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
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
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
        playerdata.PlayerBotSelection(botoption);
        playerdata.PlayerOutfitSelection(outfitoption);
        playerdata.PlayerDateSelection(dateoption);
        playerdata.PlayerNameSelection(nameoption);
        playerdata.PlayerFirstLoad();
        SceneManager.LoadScene("VisualNovel");
    }

    public void StartOver() {
        confirmscreen.SetActive(false);
        choosebotmenu.SetActive(true);
        botoption = 0;
        outfitoption = 0;
        dateoption = 0;
        nameoption = "";
    }

    public void PlayGame() {
        SceneManager.LoadScene("VisualNovel");
    }
}
