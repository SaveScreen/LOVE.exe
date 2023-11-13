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

    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        dateoption = 0;

        choosedatemenu.SetActive(true);
        confirmscreen.SetActive(false);
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
                datechoicetext.text = "Cowboy";
            break;
            case 2:
                datechoicetext.text = "Goth";
            break;
            case 3:
                datechoicetext.text = "Fancy";
            break;
        }
    }

    public void Confirm() {
        playerdata.GetPlayerOutfit();
        playerdata.PlayerFirstLoad();
        playerdata.PlayerDateSelection(dateoption);
        playerdata.SaveGame();
        SceneManager.LoadScene("VisualNovel");
    }

    public void StartOver() {
        dateoption = 0;
        choosedatemenu.SetActive(true);
        confirmscreen.SetActive(false);
    }
}
