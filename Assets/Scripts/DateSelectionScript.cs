using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DateSelectionScript : MonoBehaviour
{
    public GameObject choosedatemenu;
    public GameObject confirmscreen;
    public TextMeshProUGUI datechoicetext;
    public GameObject playerdatacontainer;
    private PlayerData playerdata;
    public int dateoption;

    private bool isChristmas;
    public GameObject[] ChristmasOverlays;
    public GameObject[] ConfirmDates;
    public GameObject[] ConfirmCrims;

    public Image CharaUiBG;
    public TextMeshProUGUI dateLikes;
    public TextMeshProUGUI dateDislikes;

    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        isChristmas = playerdata.GetChristmasTime();
        dateoption = 0;

        choosedatemenu.SetActive(true);
        confirmscreen.SetActive(false);

        if (isChristmas)
        {
            //ChristmasOverlays.SetActive(true);

            foreach (GameObject obj in ChristmasOverlays)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in ConfirmCrims)
            {
                obj.SetActive(true);
            }
        }

            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void ChooseDate(int date) {
        dateoption = date;
        choosedatemenu.SetActive(false);
        confirmscreen.SetActive(true);
        switch (dateoption) {
            case 1:
                datechoicetext.text = "Jimothy Jones";
                dateLikes.text = "The Wild West";
                dateDislikes.text = "High Class";
                ConfirmDates[0].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 69, 45, 255);
                break;
            case 2:
                datechoicetext.text = "Jett Black";
                dateLikes.text = "Goth/Alt/Punk";
                dateDislikes.text = "Tacky Styles";
                ConfirmDates[1].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(79, 115, 255, 255);
                break;
            case 3:
                datechoicetext.text = "Frills Gaudy";
                dateLikes.text = "High Class";
                dateDislikes.text = "The Lower Class";
                ConfirmDates[2].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 218, 65, 255);
                break;
            case 4:
                datechoicetext.text = "Rosaline Starr";
                dateLikes.text = "Catboys";
                dateDislikes.text = "Social Situations";
                ConfirmDates[3].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 165, 255, 255);
                break;
            case 5:
                datechoicetext.text = "Sir Michaelangelo Bouldegarde";
                dateLikes.text = "Fantasy";
                dateDislikes.text = "Reality";
                ConfirmDates[4].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(124, 255, 131, 255);
                break;
            case 6:
                datechoicetext.text = "Pierre Le’Sarcelle";
                dateLikes.text = "";
                dateDislikes.text = "The Lower Class";
                ConfirmDates[5].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(124, 247, 255, 255);
                break;
            case 7:
                datechoicetext.text = "Barry D. Money";
                dateLikes.text = "The Happy Mask";
                dateDislikes.text = "Low Sales";
                ConfirmDates[6].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(88, 214, 124, 255);
                break;
            case 8:
                datechoicetext.text = "Hitomi Nakamura";
                dateLikes.text = "Wrestling";
                dateDislikes.text = "Normal Styles";
                ConfirmDates[7].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(186, 151, 255, 255);
                break;
            case 9:
                datechoicetext.text = "Model SK 876";
                dateLikes.text = "Not Much";
                dateDislikes.text = "Work";
                ConfirmDates[8].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 162, 85, 255);
                break;
            case 10:
                datechoicetext.text = "Holo-tsune";
                dateLikes.text = "The Holo-days!";
                dateDislikes.text = "Grinches";
                ConfirmDates[9].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(174, 255, 211, 255);
                break;
        }
    }

    public void Confirm() {
        SceneManager.LoadScene("VisualNovel");
        playerdata.GetPlayerOutfit();
        playerdata.PlayerFirstLoad();
        playerdata.PlayerDateSelection(dateoption);
        playerdata.SaveGame();
        
    }

    public void StartOver() {
        dateoption = 0;
        choosedatemenu.SetActive(true);
        confirmscreen.SetActive(false);
        foreach (GameObject obj in ConfirmDates)
        {
            obj.SetActive(false);
        }
    }
}
