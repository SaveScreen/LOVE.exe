using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class ResultScript : MonoBehaviour
{
    public TMP_Text SuccessType;
    public TMP_Text FinalScore;
    public TMP_Text FinalMoney;

    public GameObject Date1;
    public GameObject Date2;
    public GameObject Date3;
    public GameObject Date4;
    public GameObject Date5;
    public GameObject Date6;
    public GameObject Date7;
    public GameObject Date8;
    public GameObject Date9;

    [Header("Cowboy")]
    public GameObject Date1C;
    public GameObject Date1B;
    public GameObject Date1A;
    public GameObject Date1S;
    [Header("Goth")]
    public GameObject Date2C;
    public GameObject Date2B;
    public GameObject Date2A;
    public GameObject Date2S;
    [Header("Fancy")]
    public GameObject Date3C;
    public GameObject Date3B;
    public GameObject Date3A;
    public GameObject Date3S;
    [Header("GamerGirl")]
    public GameObject Date4C;
    public GameObject Date4B;
    public GameObject Date4A;
    public GameObject Date4S;
    [Header("Bouldergarde")]
    public GameObject Date5C;
    public GameObject Date5B;
    public GameObject Date5A;
    public GameObject Date5S;
    [Header("Twink")]
    public GameObject Date6C;
    public GameObject Date6B;
    public GameObject Date6A;
    public GameObject Date6S;
    [Header("PyramidScheme")]
    public GameObject Date7C;
    public GameObject Date7B;
    public GameObject Date7A;
    public GameObject Date7S;
    [Header("Wrestler")]
    public GameObject Date8C;
    public GameObject Date8B;
    public GameObject Date8A;
    public GameObject Date8S;
    [Header("Shopkeeper")]
    public GameObject Date9C;
    public GameObject Date9B;
    public GameObject Date9A;
    public GameObject Date9S;

    public GameObject playerdatacontainer;
    public PlayerData playerdata;

    public GameObject moneyContainer;
    public MONEYScript moneyData;

    public GameObject RankC;
    public GameObject RankB;
    public GameObject RankA;
    public GameObject RankS;

    // Start is called before the first frame update
    void Start()
    {
        moneyData = moneyContainer.GetComponent<MONEYScript>();
        DisplayResult();
        //RankC.SetActive(false); RankB.SetActive(false); RankA.SetActive(false); RankS.SetActive(false);
    }

    public void DisplayResult()
    {
        //float scoreTemp = playerdata.GetPlayerRating() * 100;
        //FinalScore.SetText("Score: " + scoreTemp.ToString() + "%");
        
        
        switch (playerdata.GetPlayerDate())
        {
            case 1:
                Date1.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date1C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date1B.SetActive(true);
                        RankB.SetActive(true);
                        break; 
                    case 2:
                        Date1A.SetActive(true);
                        RankA.SetActive(true);
                        break; 
                    case 3:
                        Date1S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }

                break;

            case 2:
                Date3.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date2C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date2B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date2A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date2S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;

            case 3:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date3C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date3B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date3A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date3S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;
            case 4:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date4C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date4B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date4A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date4S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;
            case 5:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date5C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date5B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date5A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date5S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;
            case 6:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date6C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date6B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date6A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date6S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;
            case 7:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date7C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date7B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date7A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date7S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;
            case 8:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date8C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date8B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date8A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date8S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;
            case 9:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date9C.SetActive(true);
                        RankC.SetActive(true);
                        break;
                    case 1:
                        Date9B.SetActive(true);
                        RankB.SetActive(true);
                        break;
                    case 2:
                        Date9A.SetActive(true);
                        RankA.SetActive(true);
                        break;
                    case 3:
                        Date9S.SetActive(true);
                        RankS.SetActive(true);
                        break;
                }
                break;

        }
    }

    public int PlayerRank()
    {
        float rate = playerdata.GetPlayerRating();

        if (rate < 1)
        {
            SuccessType.SetText("FAIL");
            moneyData.AddMoney(100);
            FinalMoney.SetText("Pay: 100");
            FinalScore.SetText("Score: 70%");
            RankC.SetActive(true);
            return 0;
        }
        else if (rate >= 1 && rate < 2)
        {
            SuccessType.SetText("PASS");
            moneyData.AddMoney(300);
            FinalMoney.SetText("Pay: 300");
            FinalScore.SetText("Score: 80%");
            RankB.SetActive(true);
            return 1;
        }
        else if (rate >= 2 && rate < 2.5f)
        {
            SuccessType.SetText("GREAT");
            moneyData.AddMoney(500);
            FinalMoney.SetText("Pay: 500");
            FinalScore.SetText("Score: 90%");
            RankA.SetActive(true);
            return 2;
        }
        else
        {
            SuccessType.SetText("PERFECT");
            moneyData.AddMoney(1000);
            FinalMoney.SetText("Pay: 1000");
            FinalScore.SetText("Score: 100%");
            RankS.SetActive(true);
            return 3;
        }
    }

    public void Restart() {
        SceneManager.LoadScene("AptScene");
        playerdata.ResetPlayerRating();
        playerdata.SaveGame();
        
    }
}
