using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class VisNovelDialogueController : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public TextMeshProUGUI jptextbox;
    public CharacterData cowboy;
    public CharacterData goth;
    public CharacterData fancy;
    private string[] currentlines;
    private bool[] whoistalking;
    public bool isEnglish;
    private int index;
    public InputActionAsset inputs;
    private InputAction click;
    private bool clicked;
    private bool cutscene;
    public float textspeed;
    public bool dialoguefinished;
    public bool dialoguestarted;
    public GameObject visNovel;
    private VisNovel visNovelScript;
    public GameObject playerdatacontainer;
    private PlayerData playerdata;
    private int gamecount;
    private bool wonlastgame;
    private bool playedGame;

    // Start is called before the first frame update
    void Start()
    {
        visNovelScript = visNovel.GetComponent<VisNovel>();
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        click = inputs.FindAction("Player/MouseButton");

        index = 0;
        cutscene = true;
        textbox.text = "";
        jptextbox.text = "";
        dialoguestarted = false;
        dialoguefinished = false;
        gamecount = playerdata.GetGameCount();
        wonlastgame = playerdata.GetWin();
        playedGame = playerdata.GetPlayedGame();
        //currentlines = cowboyangrylines;
        
    }

    void OnEnable() {
        inputs.Enable();
    }

    void OnDisable() {
        inputs.Disable();
    }

    // Update is called once per frame
    void Update()
    { 
        //Dialogue has not been found yet
        if (dialoguestarted == false) {
            Debug.Log("Game is " + gamecount);
            switch (gamecount) {
                case 0:
                    switch (visNovelScript.dateref) {
                        //Cowboy
                        case 1:
                            switch (visNovelScript.datemoodref) {
                                case 1:
                                    if (isEnglish) {
                                        currentlines = cowboy.angrylines;
                                        whoistalking = cowboy.alWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpcowboyangrylines;
                                    }
                                    
                                break;
                                case 2:
                                    if (isEnglish) {
                                        currentlines = cowboy.neutrallines;
                                        whoistalking = cowboy.nlWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpcowboyneutrallines;
                                    }
                                    
                                break;

                                case 3:
                                    if (isEnglish) {
                                        currentlines = cowboy.happylines;
                                        whoistalking = cowboy.hlWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpcowboyhappylines;
                                    }
                                    
                                break;
                            }
                        break;
                        //Goth
                        case 2:
                            switch (visNovelScript.datemoodref) {
                                case 1:
                                    if (isEnglish) {
                                        currentlines = goth.angrylines;
                                        whoistalking = goth.alWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpgothangrylines;
                                    }
                                    
                                break;
                                case 2:
                                    if (isEnglish) {
                                        currentlines = goth.neutrallines;
                                        whoistalking = goth.nlWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpgothneutrallines;
                                    }
                                    
                                break;

                                case 3:
                                    if (isEnglish) {
                                        currentlines = goth.happylines;
                                        whoistalking = goth.hlWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpgothhappylines;
                                    }
                                    
                                break;
                            }
                        break;
                        //Fancy
                        case 3:
                            switch (visNovelScript.datemoodref) {
                                case 1:
                                    if (isEnglish) {
                                        currentlines = fancy.angrylines;
                                        whoistalking = fancy.alWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpfancyangrylines;
                                    }
                                    
                                break;
                                case 2:
                                    if (isEnglish) {
                                        currentlines = fancy.neutrallines;
                                        whoistalking = fancy.nlWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpfancyneutrallines;
                                    }
                                    
                                break;

                                case 3:
                                    if (isEnglish) {
                                        currentlines = fancy.happylines;
                                        whoistalking = fancy.hlWhoistalking;
                                    }
                                    else {
                                        //currentlines = jpfancyhappylines;
                                    }
                                    
                                break;
                            }
                        break;
                    }
                break;
                //After playing 1 game
                case 1:
                        if (playedGame) {
                            switch (visNovelScript.dateref) {
                                //Cowboy
                                case 1:
                                    if (wonlastgame) {
                                        currentlines = cowboy.wongamelines;
                                        whoistalking = cowboy.wongameWhoistalking;
                                    }
                                    else {
                                        currentlines = cowboy.lostgamelines;
                                        whoistalking = cowboy.lostgameWhoistalking;                                   
                                    }
                                break;
                                //Goth
                                case 2:
                                    if (wonlastgame) {
                                        currentlines = goth.wongamelines;
                                        whoistalking = goth.wongameWhoistalking;
                                    }
                                    else {
                                        currentlines = goth.lostgamelines;
                                        whoistalking = cowboy.lostgameWhoistalking;
                                    }
                                break;
                                //Fancy
                                case 3:
                                    if (wonlastgame) {
                                        currentlines = fancy.wongamelines;
                                        whoistalking = fancy.wongameWhoistalking;
                                    }
                                    else {
                                        currentlines = fancy.lostgamelines;
                                        whoistalking = cowboy.lostgameWhoistalking;
                                    }
                                break;
                            }
                        }
                        //Next Date
                        else {
                            switch (visNovelScript.dateref) {
                                //Cowboy
                                case 1:
                                    currentlines = cowboy.date2pregamelines;
                                    whoistalking = cowboy.date2preWhoistalking;
                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date2pregamelines;
                                    whoistalking = goth.date2preWhoistalking;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date2pregamelines;
                                    whoistalking = fancy.date2preWhoistalking;
                                break;
                            }
                        }
                break;
                //After playing 2 games
                case 2:
                    if (playedGame) {
                            switch (visNovelScript.dateref) {
                                //Cowboy
                                case 1:
                                    currentlines = cowboy.date2postgamelines;
                                    whoistalking = cowboy.date2postWhoistalking;
                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date2postgamelines;
                                    whoistalking = cowboy.date2postWhoistalking;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date2postgamelines;
                                    whoistalking = cowboy.date2postWhoistalking;
                                break;
                            }
                        }
                        //Next Date
                        else {
                            switch (visNovelScript.dateref) {
                                //Cowboy
                                case 1:
                                    currentlines = cowboy.date3pregamelines;
                                    whoistalking = cowboy.date3preWhoistalking;

                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date3pregamelines;
                                    whoistalking = goth.date3preWhoistalking;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date3pregamelines;
                                    whoistalking = fancy.date3preWhoistalking;
                                break;
                            }
                        }
                break;
                //After playing 3 games
                case 3:
                    if (playedGame) {
                            switch (visNovelScript.dateref) {
                                //Cowboy
                                case 1:
                                    currentlines = cowboy.date3postgamelines;
                                    whoistalking = cowboy.date3postWhoistalking;
                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date3postgamelines;
                                    whoistalking = goth.date3postWhoistalking;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date3postgamelines;
                                    whoistalking = fancy.date3postWhoistalking;
                                break;
                            }
                        }
                break;
                
            }
            StartCoroutine(TypeOutCharacters());
            dialoguestarted = true;
        }
        //When dialogue has been found.
        else {
            clicked = click.WasPressedThisFrame();
            if (cutscene) {
                if (clicked) {
                    if (isEnglish) {
                        if (textbox.text == currentlines[index]) {
                        NextPage();
                        }
                        else {
                            StopAllCoroutines();
                            textbox.text = currentlines[index];
                        }
                    }
                    else {
                        if (jptextbox.text == currentlines[index]) {
                        NextPage();
                        }
                        else {
                            StopAllCoroutines();
                            jptextbox.text = currentlines[index];
                        }
                    }
                    
                }
            }
        }
        
    }

    void NextPage() {
        if (index < currentlines.Length - 1) {
            index ++;
            if (isEnglish) {
                textbox.text = string.Empty;
                if (whoistalking[index] == false)
                {
                    textbox.color = Color.white;
                    Debug.Log("Yes");
                } 
                else
                {
                    switch (playerdata.GetPlayerBot())
                    {
                        case 0:
                            textbox.color = Color.blue;
                            Debug.Log("Yes");
                            break;
                        case 1:
                            textbox.color = new Color(255f, 105f, 180f);
                            Debug.Log("Yes");
                            break;
                        case 2:
                            textbox.color = Color.yellow;
                            Debug.Log("Yes");
                            break;
                    }
                }
            }
            else {
                jptextbox.text = string.Empty;
            }
            
            StartCoroutine(TypeOutCharacters());
        }
        else {
            dialoguefinished = true;
            index = 0;
        }
    }

    public void StartNextDatePart() {
        playedGame = false;
        dialoguefinished = false;
        index = 0;
        textbox.text = "";
        dialoguestarted = false;
    }

    IEnumerator TypeOutCharacters() {
        foreach (char c in currentlines[index].ToCharArray()) {
            if (isEnglish) {
                textbox.text += c;
            }
            else {
                jptextbox.text += c;
            }
            yield return new WaitForSeconds(textspeed);
        }
    }
}
