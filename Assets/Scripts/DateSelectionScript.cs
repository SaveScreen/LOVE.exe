using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            break;
            case 2:
                datechoicetext.text = "Jett Black";
            break;
            case 3:
                datechoicetext.text = "Frills Gaudy";
                break;
            case 4:
                datechoicetext.text = "Rosaline Starr";
                break;
            case 5:
                datechoicetext.text = "Sir Michaelangelo Bouldegarde";
                break;
            case 6:
                datechoicetext.text = "Pierre Le’Sarcelle";
                break;
            case 7:
                datechoicetext.text = "Barry D. Money";
                break;
            case 8:
                datechoicetext.text = "Hitomi Nakamura";
                break;
            case 9:
                datechoicetext.text = "Model SK 876";
                break;
            case 10:
                datechoicetext.text = "Holo-tsune";
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
    }
}
