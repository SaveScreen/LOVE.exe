using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class VisNovel : MonoBehaviour
{
    public GameObject Date1Choice;
    public GameObject Date2Choice;
    public GameObject Date3Choice;
    public GameObject Date4Choice;
    public GameObject Date5Choice;
    public GameObject Date6Choice;
    public GameObject Date7Choice;
    public GameObject Date8Choice;
    public GameObject Date9Choice;
    public GameObject Date10Choice;

    public GameObject playerdatacontainer;
    public PlayerData playerdata;

    public GameObject Angry1;
    public GameObject Neutral1;
    public GameObject Happy1;
    public GameObject christmasCowboy;

    public GameObject Angry2;
    public GameObject Neutral2;
    public GameObject Happy2;
    public GameObject christmasGoth;

    public GameObject Angry3;
    public GameObject Neutral3;
    public GameObject Happy3;
    public GameObject christmasFancy;
    
    [Header("Gamer Girl")]
    public GameObject Angry4;
    public GameObject Neutral4;
    public GameObject Happy4;
    public GameObject christmasGamergirl;
    [Header("Bouldergarde")]
    public GameObject Angry5;
    public GameObject Neutral5;
    public GameObject Happy5;
    public GameObject christmasBouldergarde;
    [Header("Twink")]
    public GameObject Angry6;
    public GameObject Neutral6;
    public GameObject Happy6;
    public GameObject christmasTwink;
    [Header("Scammer")]
    public GameObject Angry7;
    public GameObject Neutral7;
    public GameObject Happy7;
    public GameObject christmasScammer;
    [Header("Wrestler")]
    public GameObject Angry8;
    public GameObject Neutral8;
    public GameObject Happy8;
    public GameObject christmasWrestler;
    [Header("Shopkeeper")]
    public GameObject Angry9;
    public GameObject Neutral9;
    public GameObject Happy9;
    public GameObject christmasShopkeeper;
    [Header("Holo-Day Lady")]
    public GameObject Angry10;
    public GameObject Neutral10;
    public GameObject Happy10;

    [Header("Backgrounds")]
    public GameObject normalbg;
    public GameObject christmasbg;
    public GameObject christmasparticle;

    public InputActionAsset inputs;
    private InputAction click;
    private bool clicked;
    public GameObject dialogueController;
    private VisNovelDialogueController vndc;
    public int dateref;
    public int datemoodref;
    public float playerRating;
    private bool playedGame;
    private bool isChristmas;

    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        vndc = dialogueController.GetComponent<VisNovelDialogueController>();

        click = inputs.FindAction("Player/MouseButton");

        //minigamescore update
        dateref = 0;
        datemoodref = 0;
        DatePref();
        playedGame = playerdata.GetPlayedGame();
        isChristmas = playerdata.GetChristmasTime();
        Debug.Log("ischristmas" + isChristmas);

        if (isChristmas) {
            normalbg.SetActive(false);
            christmasbg.SetActive(true);
            christmasparticle.SetActive(true);
            christmasCowboy.SetActive(true);
            christmasGoth.SetActive(true);
            christmasFancy.SetActive(true);
            christmasBouldergarde.SetActive(true);
            christmasScammer.SetActive(true);
            christmasTwink.SetActive(true);
            christmasShopkeeper.SetActive(true);
            christmasGamergirl.SetActive(true);
        }
        else {
            normalbg.SetActive(true);
            christmasbg.SetActive(false);
            christmasparticle.SetActive(false);
            christmasCowboy.SetActive(false);
            christmasGoth.SetActive(false);
            christmasFancy.SetActive(false);
            christmasBouldergarde.SetActive(false);
            christmasScammer.SetActive(false);
            christmasTwink.SetActive(false);
            christmasShopkeeper.SetActive(false);
            christmasGamergirl.SetActive(false);
        }
      

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
            case 4:
                Date4(dateState);
                break;
            case 5:
                Date5(dateState);
                break;
            case 6:
                Date6(dateState);
                break;
            case 7:
                Date7(dateState);
                break;
            case 8:
                Date8(dateState);
                break;
            case 9:
                Date9(dateState);
                break;
            case 10:
                Date10(dateState);
                break;

            default:
                break;

        }
    }

    
    public void Date1(int state)
    {
        Date1Choice.SetActive(true);
        dateref = 1;
        
        switch (state)
        {
            case 1:
                Angry1.SetActive(true);
                datemoodref = 1;
                break; 
            case 2:
                Neutral1.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy1.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }

    public void Date2(int state)
    {
        Date2Choice.SetActive(true);
        dateref = 2;
        switch (state)
        {
            case 1:
                Angry2.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral2.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy2.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }

    public void Date3(int state)
    {
        Date3Choice.SetActive(true);
        dateref = 3;
        switch (state)
        {
            case 1:
                Angry3.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral3.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy3.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }

    public void Date4(int state)
    {
        Date4Choice.SetActive(true);
        dateref = 4;
        switch (state)
        {
            case 1:
                Angry4.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral4.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy4.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }

    public void Date5(int state)
    {
        Date5Choice.SetActive(true);
        dateref = 4;
        switch (state)
        {
            case 1:
                Angry5.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral5.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy5.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }

    public void Date6(int state)
    {
        Date6Choice.SetActive(true);
        dateref = 4;
        switch (state)
        {
            case 1:
                Angry6.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral6.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy6.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }
    public void Date7(int state)
    {
        Date7Choice.SetActive(true);
        dateref = 7;
        switch (state)
        {
            case 1:
                Angry7.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral7.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy7.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }
    public void Date8(int state)
    {
        Date8Choice.SetActive(true);
        dateref = 8;
        switch (state)
        {
            case 1:
                Angry8.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral8.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy8.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }
    public void Date9(int state)
    {
        Date9Choice.SetActive(true);
        dateref = 9;
        switch (state)
        {
            case 1:
                Angry9.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral9.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy9.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }
    public void Date10(int state)
    {
        Date10Choice.SetActive(true);
        dateref = 10;
        switch (state)
        {
            case 1:
                Angry10.SetActive(true);
                datemoodref = 1;
                break;
            case 2:
                Neutral10.SetActive(true);
                datemoodref = 2;
                break;
            case 3:
                Happy10.SetActive(true);
                datemoodref = 3;
                break;
        }
        Debug.Log(dateref);
        Debug.Log(datemoodref);
    }
        // Update is called once per frame
        void Update()
    {
        clicked = click.WasPressedThisFrame();
        if (clicked)
        {
            if (vndc.dialoguefinished) {
                if (playedGame && playerdata.GetGameCount() < 3) {
                    vndc.StartNextDatePart();
                    playedGame = false;
                }
                else {
                    if (playerdata.GetGameCount() < 3)
                    {
                        Debug.Log("Goingtonext");
                        switch (vndc.characters[vndc.date].minigameOrder[playerdata.GetGameCount()])
                        {
                            case 1:
                            SceneManager.LoadScene("FootballMinigame");
                            break;
                            case 2:
                            SceneManager.LoadScene("SnakeMinigame");  
                            break;
                            case 3:
                            SceneManager.LoadScene("RhythmMinigame");
                            break;
                        }
                        
                    }
                    else
                    {
                        playerdata.ResetGameCount();
                        SceneManager.LoadScene("ResultScreen");
                    }
                }
            }
        }
            

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("AptScene");
    }
}
