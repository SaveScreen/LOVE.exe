using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AptSceneMenu : MonoBehaviour
{
    public GameObject moneyContainer;
    public MONEYScript moneyData;
    public TMP_Text moneyText;
    public GameObject player;

    void Start()
    {
        int howMuch;
        moneyData = moneyContainer.GetComponent<MONEYScript>();
        howMuch = moneyData.GetGAINZ();

        moneyText.SetText("Money: " + howMuch);
    }

    public void GoToMenu() {
        PlayerData playerdata = player.GetComponent<PlayerData>();
        bool playerSelected = playerdata.GetPlayerSelected();
        //If player is selected already, go straight to the next date.
        if (playerSelected) {
            playerdata.ResetPlayedGame();
            SceneManager.LoadScene("VisualNovel");
        }
        else {
            SceneManager.LoadScene("MenuScreen");
        }
        
    }

    public void GoToStore()
    {
        SceneManager.LoadScene("StoreScene");
    }
    public void GoToCloset()
    {
        SceneManager.LoadScene("ClosetScene");
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
