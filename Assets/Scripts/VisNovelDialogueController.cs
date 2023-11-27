using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class VisNovelDialogueController : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public TextMeshProUGUI bluetextbox;
    public TextMeshProUGUI pinktextbox;
    public TextMeshProUGUI yellowtextbox; 
    public TextMeshProUGUI jptextbox;
    public CharacterData[] characters;
    private string[] currentlines;
    private bool[] whoistalking;
    public bool isEnglish;
    private bool isChristmas;
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
    [HideInInspector] public int date;

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
        bluetextbox.text = "";
        pinktextbox.text = "";
        yellowtextbox.text = "";
        dialoguestarted = false;
        dialoguefinished = false;
        
        gamecount = playerdata.GetGameCount();
        wonlastgame = playerdata.GetWin();
        playedGame = playerdata.GetPlayedGame();
        date = playerdata.GetPlayerDate() - 1;
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
                    switch (visNovelScript.datemoodref) {
                        case 1:
                            if (isEnglish) {
                                currentlines = characters[date].angrylines;
                                whoistalking = characters[date].alWhoistalking;
                            }
                            else {
                                //currentlines = jpcowboyangrylines;
                            }                        
                        break;
                        case 2:
                            if (isEnglish) {
                                currentlines = characters[date].neutrallines;
                                whoistalking = characters[date].nlWhoistalking;
                            }
                            else {
                                //currentlines = jpcowboyneutrallines;
                            }                            
                        break;
                        case 3:
                            if (isEnglish) {
                                currentlines = characters[date].happylines;
                                whoistalking = characters[date].hlWhoistalking;
                            }
                            else {
                                //currentlines = jpcowboyhappylines;
                            }      
                        break;
                    }                    
                break;
                //After playing 1 game
                case 1:
                    if (playedGame) {    
                        if (wonlastgame) {
                            currentlines = characters[date].wongamelines;
                            whoistalking = characters[date].wongameWhoistalking;
                        }
                        else {
                            currentlines = characters[date].lostgamelines;
                            whoistalking = characters[date].lostgameWhoistalking;                                   
                        }    
                    }
                    //Next Date
                    else {
                        currentlines = characters[date].date2pregamelines;
                        whoistalking = characters[date].date2preWhoistalking;    
                    }
                break;
                //After playing 2 games
                case 2:
                    if (playedGame) {
                        currentlines = characters[date].date2postgamelines;
                        whoistalking = characters[date].date2postWhoistalking;     
                    }
                    //Next Date
                    else {
                        currentlines = characters[date].date3pregamelines;
                        whoistalking = characters[date].date3preWhoistalking;                            
                    }
                break;
                //After playing 3 games
                case 3:
                    if (playedGame) {
                        currentlines = characters[date].date3postgamelines;
                        whoistalking = characters[date].date3postWhoistalking;    
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
                        if (whoistalking[index] == false) {
                            if (textbox.text == currentlines[index]) {
                                NextPage();
                            }
                            else {
                                StopAllCoroutines();
                                textbox.text = currentlines[index];
                            }
                        }
                        else {
                            switch (playerdata.GetPlayerBot()) {
                                case 3:
                                    if (pinktextbox.text == currentlines[index]) {
                                        NextPage();
                                    }
                                    else {
                                        StopAllCoroutines();
                                        pinktextbox.text = currentlines[index];
                                    } 
                                break;
                                case 1:
                                    if (bluetextbox.text == currentlines[index]) {
                                        NextPage();
                                    }
                                    else {
                                        StopAllCoroutines();
                                        bluetextbox.text = currentlines[index];
                                    }
                                break;
                                case 2:
                                    if (yellowtextbox.text == currentlines[index]) {
                                        NextPage();
                                    }
                                    else {
                                        StopAllCoroutines();
                                        yellowtextbox.text = currentlines[index];
                                    }
                                break;
                            }
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
                bluetextbox.text = string.Empty;
                pinktextbox.text = string.Empty;
                yellowtextbox.text = string.Empty;
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
        bluetextbox.text = "";
        pinktextbox.text = "";
        yellowtextbox.text = "";
        dialoguestarted = false;
    }

    IEnumerator TypeOutCharacters() {
        foreach (char c in currentlines[index].ToCharArray()) {
            if (isEnglish) {
                if (whoistalking[index] == false) {
                    textbox.text += c;
                } else {
                    switch (playerdata.GetPlayerBot()) {
                        case 3:
                            pinktextbox.text += c;
                        break;
                        case 1:
                            bluetextbox.text += c;
                        break;
                        case 2:
                            yellowtextbox.text += c;
                        break;
                    }
                }
            }
            else {
                jptextbox.text += c;
            }
            yield return new WaitForSeconds(textspeed);
        }
    }
}
