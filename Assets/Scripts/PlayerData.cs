using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int playerbot = 0;
    public static int playeroutfit = 0;
    public static int playerdate = 0;
    public static string playername = "";

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
}
