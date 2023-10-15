using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class VisNovel : MonoBehaviour
{
    public GameObject Date1Choice;
    public GameObject Date2Choice;
    public GameObject Date3Choice;
    public GameObject playerdatacontainer;
    public PlayerData playerdata;
    public GameObject Angry1;
    public GameObject Neutral1;
    public GameObject Happy1;
    public GameObject Angry2;
    public GameObject Neutral2;
    public GameObject Happy2;
    public GameObject Angry3;
    public GameObject Neutral3;
    public GameObject Happy3;
    public InputActionAsset inputs;
    private InputAction click;
    private bool clicked;

    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();

        click = inputs.FindAction("Player/MouseButton");

        //minigamescore update

        DatePref();
      

    }

    void OnEnable()
    {
        inputs.Enable();
    }

    void OnDisable()
    {
        inputs.Disable();
    }

    public void DatePref()
    {
        float playerRating;
        int playerDate = playerdata.GetPlayerDate();
        playerRating = playerdata.PlayerLikeRating(playerDate);
        int dateState = 0;

        if (playerRating < .5)
            dateState = 1;
        else if (playerRating >= 0.5 && playerRating < 1)
            dateState = 2;
        else
            dateState = 3;


        switch (playerDate)
        {
            case 1:
                Date1(dateState);
                break;
            case 2:
                Date2(dateState);
                break;
            case 3:
                Date3(dateState);
                break;
            default:
                break;

        }
    }


    
    public void Date1(int state)
    {
        Date1Choice.SetActive(true);
        switch (state)
        {
            case 1:
                Angry1.SetActive(true);
                break; 
            case 2:
                Neutral1.SetActive(true);
                break;
            case 3:
                Happy1.SetActive(true);
                break;
        }
    }

    public void Date2(int state)
    {
        Date2Choice.SetActive(true);
        switch (state)
        {
            case 1:
                Angry2.SetActive(true);
                break;
            case 2:
                Neutral2.SetActive(true);
                break;
            case 3:
                Happy2.SetActive(true);
                break;
        }
    }

    public void Date3(int state)
    {
        Date3Choice.SetActive(true);
        switch (state)
        {
            case 1:
                Angry3.SetActive(true);
                break;
            case 2:
                Neutral3.SetActive(true);
                break;
            case 3:
                Happy3.SetActive(true);
                break;
        }
    }



    // Update is called once per frame
    void Update()
    {
        clicked = click.WasPressedThisFrame();
        if (clicked)
            SceneManager.LoadScene("FootballMinigame");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
