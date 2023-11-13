using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{

    public GameObject choosebotmenu;
    public GameObject choosenamemenu;
    public GameObject confirmscreen;
    public int botoption; //If option is set to 0, it will say no bot has been chosen
    public string nameoption;
    public TMP_InputField nametext;
    public TextMeshProUGUI botchoicetext;
    public TextMeshProUGUI namechoicetext;
    public GameObject playerdatacontainer;
    private PlayerData playerdata;


    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        botoption = 0;
        nameoption = "";

        choosebotmenu.SetActive(true);  
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void ChooseBotOption(int option) {
        //Options: 1 = Male, 2 = Female, 3 = Neutral
        botoption = option;
        choosebotmenu.SetActive(false);
        choosenamemenu.SetActive(true);
        Debug.Log("Chose option " + botoption);
    }

    public void ChooseNameOption() {
        nameoption = nametext.text;
        choosenamemenu.SetActive(false);
        confirmscreen.SetActive(true);
        if (botoption == 1) {
            botchoicetext.text = "Model_M";
        }
        if (botoption == 2) {
            botchoicetext.text = "Model_S";
        }
        if (botoption == 3) {
            botchoicetext.text = "Model_T";
        }
        namechoicetext.text = nameoption;
        Debug.Log("Name chosen as " + nameoption);
    }

    public void Confirm() {
        playerdata.PlayerBotSelection(botoption);
        playerdata.PlayerNameSelection(nameoption);
        playerdata.PlayerFirstLoad();
        playerdata.PlayerSelected();
        playerdata.SaveGame();
        SceneManager.LoadScene("AptScene");
    }

    public void StartOver() {
        confirmscreen.SetActive(false);
        choosebotmenu.SetActive(true);
        botoption = 0;
        nameoption = "";  
    }

}
