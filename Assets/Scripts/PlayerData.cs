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
                if (playeroutfit == 1)
                    playerRating += 0.5f;
                else if (playeroutfit == 2)
                    playerRating += 0.2f;
                else
                    playerRating += 0;
                return playerRating;

            case 2: //Goth
                if (playeroutfit == 2)
                    playerRating += 0.5f;
                else if (playeroutfit == 3)
                    playerRating += 0.2f;
                else
                    playerRating += 0;
                return playerRating;

            case 3: //Fancy
                if (playeroutfit == 3)
                    playerRating += 0.5f;
                else if (playeroutfit == 1)
                    playerRating += 0.2f;
                else
                    playerRating += 0;
                return playerRating;

            default:
                return 0;
        }

    }
}
