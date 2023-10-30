using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AptSceneMenu : MonoBehaviour
{
    public GameObject moneyContainer;
    public MONEYScript moneyData;
    public TMP_Text moneyText;

    void Start()
    {
        int howMuch;
        moneyData = moneyContainer.GetComponent<MONEYScript>();
        howMuch = moneyData.GetGAINZ();

        moneyText.SetText("Money: " + howMuch);
    }

    public void GoToMenu() {
        SceneManager.LoadScene("MenuScreen");
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
