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

    public static int rhythmgamehiscore = 0;
    public static int snakegamehiscore = 0;

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
        gameData.snakegamehiscore = snakegamehiscore;
        gameData.rhythmgamehiscore = rhythmgamehiscore;

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
        snakegamehiscore = gameData.snakegamehiscore;
        rhythmgamehiscore = gameData.rhythmgamehiscore;
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

    public void NewRhythmGameHiScore(int score) {
        rhythmgamehiscore = score;
    }

    public void NewSnakeGameHiScore(int score) {
        snakegamehiscore = score;
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
    public void ResetPlayerRating() {
        playerRating = 0;
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
        playeroutfit = sel;

        Debug.Log("Outfit Selected: " + sel);
    }

    public int GetPlayerChibiOutfit()
    {
        return playerChibiOutfit;
    }

    public int GetRhythmGameHiScore() {
        return rhythmgamehiscore;
    }

    public int GetSnakeGameHiScore() {
        return snakegamehiscore;
    }

    public float PlayerLikeRating(int dateNum)
    {
        switch(dateNum)
        {
            //1 is cowboy, 2 is fancy, 3 is goth
            case 1: //Cowboy
                if (firstLoad)
                {
                    if (playeroutfit == 1)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0,1f);
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
                    if (playeroutfit == 3)
                        playerRating += 1f;
                    else if (playeroutfit == 2)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0.0f,1.0f);
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
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 1)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0,1f);
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 4: //Gamer
                if (firstLoad)
                {
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0, 1f);
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 5: //Gamer
                if (firstLoad)
                {
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0, 1f);
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 6: //Gamer
                if (firstLoad)
                {
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0, 1f);
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 7: //Gamer
                if (firstLoad)
                {
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0, 1f);
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 8: //Gamer
                if (firstLoad)
                {
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0, 1f);
                    else
                        playerRating += 0;
                    Debug.Log("Firstloaded");
                }
                firstLoad = false;
                Debug.Log("Player Rating: " + playerRating);
                return playerRating;

            case 9: //Gamer
                if (firstLoad)
                {
                    if (playeroutfit == 2)
                        playerRating += 1f;
                    else if (playeroutfit == 3)
                        playerRating += 0.5f;
                    else if (playeroutfit > 3)
                        playerRating += Random.Range(0, 1f);
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
        rhythmgamehiscore = 0;
        snakegamehiscore = 0;
        moneyScript.SetMoney(0);
    }

}
