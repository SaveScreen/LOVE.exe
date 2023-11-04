using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugRoomScript : MonoBehaviour
{
    public GameObject player;
    private PlayerData playerdata;
    public TextMeshProUGUI playerdatetext;
    public TextMeshProUGUI playerbottext;
    public TextMeshProUGUI playeroutfittext;
    public TextMeshProUGUI playernametext;
    public TextMeshProUGUI playerratingtext;
    public TextMeshProUGUI playerselectedtext;
    private int playerdate;
    private int playerbot;
    private int playeroutfit;
    private string playername;
    private float playerrating;
    private bool playerselected;

    void Start() {
        playerdata = player.GetComponent<PlayerData>();

        playerdate = playerdata.GetPlayerDate();
        playerbot = playerdata.GetPlayerBot();
        playeroutfit = playerdata.GetPlayerOutfit();
        playername = playerdata.GetPlayerName();
        playerrating = playerdata.GetPlayerRating();
        playerselected = playerdata.GetPlayerSelected();

        playerdatetext.text = "Date: " + playerdate;
        playerbottext.text = "Bot: " + playerbot;
        playeroutfittext.text = "Outfit: " + playeroutfit;
        playernametext.text = "Name: " + playername;
        playerratingtext.text = "Rating: " + playerrating;
        playerselectedtext.text = "Selected: " + playerselected;

    }

    void Update() {
        if (playerdata.restarting == true) {
            playerdatetext.text = "Date: ";
            playerbottext.text = "Bot: ";
            playeroutfittext.text = "Outfit: ";
            playernametext.text = "Name: ";
            playerratingtext.text = "Rating: ";
            playerselectedtext.text = "Selected: ";
            playerdata.restarting = false;
        }
        
        else if (playerdata.loadingdata == true) {
            playerdate = playerdata.GetPlayerDate();
            playerbot = playerdata.GetPlayerBot();
            playeroutfit = playerdata.GetPlayerOutfit();
            playername = playerdata.GetPlayerName();
            playerrating = playerdata.GetPlayerRating();
            playerselected = playerdata.GetPlayerSelected();

            playerdatetext.text = "Date: " + playerdate;
            playerbottext.text = "Bot: " + playerbot;
            playeroutfittext.text = "Outfit: " + playeroutfit;
            playernametext.text = "Name: " + playername;
            playerratingtext.text = "Rating: " + playerrating;
            playerselectedtext.text = "Selected: " + playerselected;
            playerdata.loadingdata = false;
        }
    }

    public void GoToApartment() {
        SceneManager.LoadScene("AptScene");
    }
}
