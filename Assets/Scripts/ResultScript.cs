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

    public GameObject Date1;
    public GameObject Date2;
    public GameObject Date3;

    public GameObject Date1C;
    public GameObject Date1B;
    public GameObject Date1A;
    public GameObject Date1S;

    public GameObject Date2C;
    public GameObject Date2B;
    public GameObject Date2A;
    public GameObject Date2S;

    public GameObject Date3C;
    public GameObject Date3B;
    public GameObject Date3A;
    public GameObject Date3S;

    public GameObject playerdatacontainer;
    public PlayerData playerdata;

    // Start is called before the first frame update
    void Start()
    {
        DisplayResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayResult()
    {
        FinalScore.SetText("Score: " + playerdata.GetPlayerRating().ToString());

        switch (playerdata.GetPlayerDate())
        {
            case 1:
                Date1.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date1C.SetActive(true);
                        break;
                    case 1:
                        Date1B.SetActive(true);
                        break; 
                    case 2:
                        Date1A.SetActive(true);
                        break; 
                    case 3:
                        Date1S.SetActive(true);
                        break;
                }

                break;

            case 2:
                Date2.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date2C.SetActive(true);
                        break;
                    case 1:
                        Date2B.SetActive(true);
                        break;
                    case 2:
                        Date2A.SetActive(true);
                        break;
                    case 3:
                        Date2S.SetActive(true);
                        break;
                }

                break;

            case 3:
                Date3.SetActive(true);
                switch (PlayerRank())
                {
                    case 0:
                        Date3C.SetActive(true);
                        break;
                    case 1:
                        Date3B.SetActive(true);
                        break;
                    case 2:
                        Date3A.SetActive(true);
                        break;
                    case 3:
                        Date3S.SetActive(true);
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
            return 0;
        }
        else if (rate >= 1 && rate < 2)
        {
            SuccessType.SetText("PASS");
            return 1;
        }
        else if (rate >= 2 && rate < 2.5f)
        {
            SuccessType.SetText("GREAT");
            return 2;
        }
        else
        {
            SuccessType.SetText("PERFECT");
            return 3;
        }
    }
}
