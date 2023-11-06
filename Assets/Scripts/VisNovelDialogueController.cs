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
    /*
    public string[] cowboyangrylines;
    public string[] cowboyneutrallines;
    public string[] cowboyhappylines;
    public string[] gothangrylines;
    public string[] gothneutrallines;
    public string[] gothhappylines;
    public string[] fancyangrylines;
    public string[] fancyneutrallines;
    public string[] fancyhappylines;
    public string[] cowboyloselines;
    public string[] cowboywinlines;
    public string[] gothloselines;
    public string[] gothwinlines;
    public string[] fancyloselines;
    public string[] fancywinlines;
    public string[] cowboydate2lines;
    public string[] gothdate2lines;
    public string[] fancydate2lines;
    public string[] cowboydate3lines;
    public string[] gothdate3lines;
    public string[] fancydate3lines;
    */
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
                                    }
                                    else {
                                        //currentlines = jpcowboyangrylines;
                                    }
                                    
                                break;
                                case 2:
                                    if (isEnglish) {
                                        currentlines = cowboy.neutrallines;
                                    }
                                    else {
                                        //currentlines = jpcowboyneutrallines;
                                    }
                                    
                                break;

                                case 3:
                                    if (isEnglish) {
                                        currentlines = cowboy.happylines;
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
                                    }
                                    else {
                                        //currentlines = jpgothangrylines;
                                    }
                                    
                                break;
                                case 2:
                                    if (isEnglish) {
                                        currentlines = goth.neutrallines;
                                    }
                                    else {
                                        //currentlines = jpgothneutrallines;
                                    }
                                    
                                break;

                                case 3:
                                    if (isEnglish) {
                                        currentlines = goth.happylines;
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
                                    }
                                    else {
                                        //currentlines = jpfancyangrylines;
                                    }
                                    
                                break;
                                case 2:
                                    if (isEnglish) {
                                        currentlines = fancy.neutrallines;
                                    }
                                    else {
                                        //currentlines = jpfancyneutrallines;
                                    }
                                    
                                break;

                                case 3:
                                    if (isEnglish) {
                                        currentlines = fancy.happylines;
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
                                    }
                                    else {
                                        currentlines = cowboy.lostgamelines;
                                    }
                                break;
                                //Goth
                                case 2:
                                    if (wonlastgame) {
                                        currentlines = goth.wongamelines;
                                    }
                                    else {
                                        currentlines = goth.lostgamelines;
                                    }
                                break;
                                //Fancy
                                case 3:
                                    if (wonlastgame) {
                                        currentlines = fancy.wongamelines;
                                    }
                                    else {
                                        currentlines = fancy.lostgamelines;
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
                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date2pregamelines;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date2pregamelines;
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
                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date2postgamelines;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date2postgamelines;
                                break;
                            }
                        }
                        //Next Date
                        else {
                            switch (visNovelScript.dateref) {
                                //Cowboy
                                case 1:
                                    currentlines = cowboy.date3pregamelines;
                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date3pregamelines;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date3pregamelines;
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
                                break;
                                //Goth
                                case 2:
                                    currentlines = goth.date3postgamelines;
                                break;
                                //Fancy
                                case 3:
                                    currentlines = fancy.date3postgamelines;
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
