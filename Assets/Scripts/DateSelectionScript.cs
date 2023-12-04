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
                dateLikes.text = "The Wild West <br> Yallternative";
                dateDislikes.text = "City Slickers <br> Snobby Folk";
                ConfirmDates[0].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 69, 45, 255);
                break;
            case 2:
                datechoicetext.text = "Jett Black";
                dateLikes.text = "Goth/Alt/Punk <br> Cult Classics";
                dateDislikes.text = "Tacky Styles <br> Boring People";
                ConfirmDates[1].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(79, 115, 255, 255);
                break;
            case 3:
                datechoicetext.text = "Frills Gaudy";
                dateLikes.text = "High Fashion <br> Luxurious Parties";
                dateDislikes.text = "The Unfashionable <br> Slacking Off";
                ConfirmDates[2].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 218, 65, 255);
                break;
            case 4:
                datechoicetext.text = "Rosaline Starr";
                dateLikes.text = "Videogames <br> Anime";
                dateDislikes.text = "Social Situations <br> Parties";
                ConfirmDates[3].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 165, 255, 255);
                break;
            case 5:
                datechoicetext.text = "Sir Michaelangelo Bouldegarde";
                dateLikes.text = "Taverns and Trolls <br> Anime";
                dateDislikes.text = "Wenches <br> Tech-deniers";
                ConfirmDates[4].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(124, 255, 131, 255);
                break;
            case 6:
                datechoicetext.text = "Pierre Le Sarcelle";
                dateLikes.text = "Being Pampered <br> Luxurious Gifts";
                dateDislikes.text = "Old People Fashion <br> Poor People";
                ConfirmDates[5].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(124, 247, 255, 255);
                break;
            case 7:
                datechoicetext.text = "Barry D. Money";
                dateLikes.text = "The Happy Mask <br> Big Wallets";
                dateDislikes.text = "Vacations <br> Intimidating Figures";
                ConfirmDates[6].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(88, 214, 124, 255);
                break;
            case 8:
                datechoicetext.text = "Hitomi Nakamura";
                dateLikes.text = "Wrestling <br> Lolita Fashion";
                dateDislikes.text = "Evil Heels <br> Snobby Villans";
                ConfirmDates[7].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(186, 151, 255, 255);
                break;
            case 9:
                datechoicetext.text = "Model SK 876";
                dateLikes.text = "Vacations <br> Parties";
                dateDislikes.text = "The Rich <br> Customers";
                ConfirmDates[8].SetActive(true);
                CharaUiBG.GetComponent<Image>().color = new Color32(255, 162, 85, 255);
                break;
            case 10:
                datechoicetext.text = "Holo-tsune";
                dateLikes.text = "The Holo-days! <br> Raves!";
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
