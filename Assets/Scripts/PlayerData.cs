using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int playerbot = 0;
    public static int playeroutfit = 0;
    public static int playerdate = 0;
    public static string playername = "";
    public static float playerRating = 0;
    public static bool firstLoad = false;

    public void PlayerBotSelection(int selection) {
        playerbot = selection;
    }
    public void PlayerOutfitSelection(int selection) {
        playeroutfit = selection;
    }
    public void PlayerDateSelection(int selection) {
        playerdate = selection;
    }
    public void PlayerNameSelection(string selection) {
        playername = selection;
    }
    public void PlayerFirstLoad()
    {
        firstLoad = true;
    }

    public int GetPlayerBot()
    {
        return playerbot;
    }
    public int GetPlayerOutfit()
    {
        return playeroutfit;
    }
    public int GetPlayerDate()
    {
        return playerdate;
    }
    public string GetPlayerName()
    {
        return playername;
    }

    public float PlayerLikeRating(int dateNum)
    {
        switch(dateNum)
        {
            case 1: //Cowboy
                if (firstLoad)
                {
                    if (playeroutfit == 1)
                        playerRating += 1f;
                    else if (playeroutfit == 2)
                        playerRating += 0.5f;
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 2: //Goth
                if (firstLoad)
                {
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 3: //Fancy
                if (firstLoad)
                {
                    if (playeroutfit == 3)
                        playerRating += 1f;
                    else if (playeroutfit == 1)
                        playerRating += 0.5f;
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            default:
                return 0;
        }
    }

    public void UpdatePlayerDateScore(bool didWin)
    {
        if (didWin)
            playerRating += .6f;
        else
            playerRating -= .3f;

        Debug.Log("Player Rating: " + playerRating);
    }

}
