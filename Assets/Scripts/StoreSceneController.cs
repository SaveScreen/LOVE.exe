using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoreSceneController : MonoBehaviour
{
    public GameObject moneyContainer;
    public MONEYScript moneyData;
    public TMP_Text moneyText;

    void Start()
    {
        moneyData = moneyContainer.GetComponent<MONEYScript>();
        GetMoney();
    }

    public void GetMoney()
    {
        int howMuch;
        howMuch = moneyData.GetGAINZ();

        moneyText.SetText("Money: " + howMuch);
    }

    public void GoToApartment()
    {
        SceneManager.LoadScene("AptScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
