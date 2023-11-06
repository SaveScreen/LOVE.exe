using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int playerbot = 0;
    public static int playeroutfit = 0;
    public static int playerdate = 0;
    public static string playername = "";
    public static float playerRating = 0;
    public static bool firstLoad = false;
    public static int gameCount = 0;
    public static bool wonGame = false;
    public static bool playedGame = false;
    public static bool playerSelected = false;
    public static int playerChibiOutfit;
    
    public bool loadingdata = false;
    public bool restarting = false;

    public static bool[] isOutfitUnlocked = new bool[7];

    public MONEYScript moneyScript;

    public void NewGame() {
        ResetAllData();
        restarting = true;
    }

    public void SaveGame() {
        int money = moneyScript.GetGAINZ();

        GameDataStorage gameData = new GameDataStorage();
        gameData.playerSelected = playerSelected;
        gameData.playerDate = playerdate;
        gameData.playerName = playername;
        gameData.playerOutfit = playeroutfit;
        gameData.playerRating = playerRating;
        gameData.playerBot = playerbot;
        gameData.isOutfitUnlocked = isOutfitUnlocked;
        gameData.money = money;

        string json = JsonUtility.ToJson(gameData,false);
        File.WriteAllText(Application.dataPath + "/PlayerDataFile.json",json);
    }

    //Checks if there is a JSON that exists on the system
    public void InitialFileCheck() {
        string json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.json");
        GameDataStorage gameData = JsonUtility.FromJson<GameDataStorage>(json);
        if (gameData != null) {
            playerSelected = gameData.playerSelected;
        }
        else {
            playerSelected = false;
        }
    }
    public void LoadGame() {
        string json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.json");
        GameDataStorage gameData = JsonUtility.FromJson<GameDataStorage>(json);
        playerSelected = gameData.playerSelected;
        playerdate = gameData.playerDate;
        playername = gameData.playerName;
        playeroutfit = gameData.playerOutfit;
        playerRating = gameData.playerRating;
        playerbot = gameData.playerBot;
        isOutfitUnlocked = gameData.isOutfitUnlocked;
        int money = gameData.money;
        moneyScript.SetMoney(money);

        loadingdata = true;
    }

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
    public void PlayerSelected() {
        playerSelected = true;
    }
    public void IncreaseGameCount()
    {
        gameCount++;
    }
    public void ResetGameCount()
    {
        gameCount = 0;
    }
    public void ResetPlayedGame() {
        playedGame = false;
    }
    public void UnlockOutfit(int outfitNum)
    {
        isOutfitUnlocked[outfitNum] = true;
    }

    public void WonGame() {
        wonGame = true;
        playedGame = true;
    }
    public void LostGame() {
        wonGame = false;
        playedGame = true;
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
    public int GetGameCount()
    {
        return gameCount;
    }
    public bool GetWin() {
        return wonGame;
    }
    public bool GetPlayedGame() {
        return playedGame;
    }
    public float GetPlayerRating()
    {
        return playerRating;
    }
    public bool GetPlayerSelected() {
        return playerSelected;
    }
    public bool getOutfitUnlocked(int fitSlot)
    {
        return isOutfitUnlocked[fitSlot];
    }

    public void SetPlayerChibiOutfit(int sel)
    {
        playerChibiOutfit = sel;

        Debug.Log("Outfit Selected: " + sel);
    }

    public int GetPlayerChibiOutfit()
    {
        return playerChibiOutfit;
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

    public void ResetAllData() {
        playerbot = 0;
        playeroutfit = 0;
        playerdate = 0;
        playername = "";
        playerRating = 0;
        firstLoad = false;
        gameCount = 0;
        wonGame = false;
        playedGame = false;
        playerSelected = false;
    }

}
