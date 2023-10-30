using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AptSceneMenu : MonoBehaviour
{
    public GameObject player;

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

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
