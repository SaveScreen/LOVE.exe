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
    public TextMeshProUGUI jpbluetextbox;
    public TextMeshProUGUI jppinktextbox;
    public TextMeshProUGUI jpyellowtextbox;
    public CharacterData[] characters;
    public CharacterData[] jpCharacters;
    private string[] currentlines;
    private bool[] whoistalking;
    private int language;
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
        jpbluetextbox.text = "";
        jppinktextbox.text = "";
        jpyellowtextbox.text = "";
        dialoguestarted = false;
        dialoguefinished = false;
        
        gamecount = playerdata.GetGameCount();
        wonlastgame = playerdata.GetWin();
        playedGame = playerdata.GetPlayedGame();
        date = playerdata.GetPlayerDate() - 1;
        isChristmas = playerdata.GetChristmasTime();
        language = playerdata.GetLanguage();
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
                            if (language == 0) {
                                //English Lines
                                if (isChristmas)
                                {
                                    currentlines = characters[date].christmasangrylines;
                                    whoistalking = characters[date].christmasalWhoistalking;
                                }
                                else
                                {
                                    currentlines = characters[date].angrylines;
                                    whoistalking = characters[date].alWhoistalking;
                                }
                            }
                            else {
                                //Japanese Lines
                                if (isChristmas)
                                {
                                    currentlines = jpCharacters[date].christmasangrylines;
                                    whoistalking = jpCharacters[date].christmasalWhoistalking;
                                }
                                else
                                {
                                    currentlines = jpCharacters[date].angrylines;
                                    whoistalking = jpCharacters[date].alWhoistalking;
                                }
                            }                        
                        break;
                        case 2:
                            if (language == 0) {
                                if (isChristmas)
                                {
                                    currentlines = characters[date].christmasneutrallines;
                                    whoistalking = characters[date].christmasnlWhoistalking;
                                }
                                else
                                {
                                    currentlines = characters[date].neutrallines;
                                    whoistalking = characters[date].nlWhoistalking;
                                }
                                
                            }
                            else {
                                if (isChristmas)
                                {
                                    currentlines = jpCharacters[date].christmasneutrallines;
                                    whoistalking = jpCharacters[date].christmasnlWhoistalking;
                                }
                                else
                                {
                                    currentlines = jpCharacters[date].neutrallines;
                                    whoistalking = jpCharacters[date].nlWhoistalking;
                                }
                            }                            
                        break;
                        case 3:
                            if (language == 0) {
                                if (isChristmas)
                                {
                                    currentlines = characters[date].christmashappylines;
                                    whoistalking = characters[date].christmashlWhoistalking;
                                }
                                else
                                {
                                    currentlines = characters[date].happylines;
                                    whoistalking = characters[date].hlWhoistalking;
                                }
                               
                            }
                            else {
                                if (isChristmas)
                                {
                                    currentlines = jpCharacters[date].christmashappylines;
                                    whoistalking = jpCharacters[date].christmashlWhoistalking;
                                }
                                else
                                {
                                    currentlines = jpCharacters[date].happylines;
                                    whoistalking = jpCharacters[date].hlWhoistalking;
                                }
                            }      
                        break;
                    }                    
                break;
                //After playing 1 game
                case 1:
                    if (playedGame) {    
                        if (wonlastgame) {
                            if (language == 0) {
                                if (isChristmas)
                                {
                                    currentlines = characters[date].christmaswongamelines;
                                    whoistalking = characters[date].christmaswongameWhoistalking;
                                }
                                else
                                {
                                    currentlines = characters[date].wongamelines;
                                    whoistalking = characters[date].wongameWhoistalking;
                                }
                            }
                            else {
                                if (isChristmas)
                                {
                                    currentlines = jpCharacters[date].christmaswongamelines;
                                    whoistalking = jpCharacters[date].christmaswongameWhoistalking;
                                }
                                else
                                {
                                    currentlines = jpCharacters[date].wongamelines;
                                    whoistalking = jpCharacters[date].wongameWhoistalking;
                                }
                            }
                        }
                        else {
                            if (language == 0) {
                                if (isChristmas)
                                {
                                    currentlines = characters[date].christmaslostgamelines;
                                    whoistalking = characters[date].christmaslostgameWhoistalking;
                                }
                                else
                                {
                                    currentlines = characters[date].lostgamelines;
                                    whoistalking = characters[date].lostgameWhoistalking;
                                }
                            }
                            else {
                                if (isChristmas)
                                {
                                    currentlines = jpCharacters[date].christmaslostgamelines;
                                    whoistalking = jpCharacters[date].christmaslostgameWhoistalking;
                                }
                                else
                                {
                                    currentlines = jpCharacters[date].lostgamelines;
                                    whoistalking = jpCharacters[date].lostgameWhoistalking;
                                }
                            }                                      
                        }    
                    }
                    //Next Date
                    else {
                        if (language == 0) {
                            if (isChristmas)
                            {
                                currentlines = characters[date].christmasdate2pregamelines;
                                whoistalking = characters[date].christmasdate2preWhoistalking;
                            }
                            else
                            {
                                currentlines = characters[date].date2pregamelines;
                                whoistalking = characters[date].date2preWhoistalking;
                            }
                        }
                        else {
                            if (isChristmas)
                            {
                                currentlines = jpCharacters[date].christmasdate2pregamelines;
                                whoistalking = jpCharacters[date].christmasdate2preWhoistalking;
                            }
                            else
                            {
                                currentlines = jpCharacters[date].date2pregamelines;
                                whoistalking = jpCharacters[date].date2preWhoistalking;
                            }
                        }          
                    }
                break;
                //After playing 2 games
                case 2:
                    if (playedGame) {
                        if (language == 0) {
                            if (isChristmas)
                            {
                                currentlines = characters[date].christmasdate2postgamelines;
                                whoistalking = characters[date].christmasdate2postWhoistalking;
                            }
                            else
                            {
                                currentlines = characters[date].date2postgamelines;
                                whoistalking = characters[date].date2postWhoistalking;
                            }
                        }
                        else {
                            if (isChristmas)
                            {
                                currentlines = jpCharacters[date].christmasdate2postgamelines;
                                whoistalking = jpCharacters[date].christmasdate2postWhoistalking;
                            }
                            else
                            {
                                currentlines = jpCharacters[date].date2postgamelines;
                                whoistalking = jpCharacters[date].date2postWhoistalking;
                            }
                        }     
                    }
                    //Next Date
                    else {
                        if (language == 0) {
                            if (isChristmas)
                            {
                                currentlines = characters[date].christmasdate3pregamelines;
                                whoistalking = characters[date].christmasdate3preWhoistalking;
                            }
                            else
                            {
                                currentlines = characters[date].date3pregamelines;
                                whoistalking = characters[date].date3preWhoistalking;
                            }
                        }
                        else {
                            if (isChristmas)
                            {
                                currentlines = jpCharacters[date].christmasdate3pregamelines;
                                whoistalking = jpCharacters[date].christmasdate3preWhoistalking;
                            }
                            else
                            {
                                currentlines = jpCharacters[date].date3pregamelines;
                                whoistalking = jpCharacters[date].date3preWhoistalking;
                            }
                        }                            
                    }
                break;
                //After playing 3 games
                case 3:
                    if (playedGame) {
                        if (language == 0) {
                            if (isChristmas)
                            {
                                currentlines = characters[date].christmasdate3postgamelines;
                                whoistalking = characters[date].christmasdate3postWhoistalking;
                            }
                            else
                            {
                                currentlines = characters[date].date3postgamelines;
                                whoistalking = characters[date].date3postWhoistalking;
                            }
                        }
                        else {
                            if (isChristmas)
                            {
                                currentlines = jpCharacters[date].christmasdate3postgamelines;
                                whoistalking = jpCharacters[date].christmasdate3postWhoistalking;
                            }
                            else
                            {
                                currentlines = jpCharacters[date].date3postgamelines;
                                whoistalking = jpCharacters[date].date3postWhoistalking;
                            }
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
                    if (language == 0) {
                        //FOR ENGLISH DIALOGUE
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
                        //FOR JAPANESE DIALOGUE
                        if (whoistalking[index] == false) {
                            if (jptextbox.text == currentlines[index]) {
                                NextPage();
                            }
                            else {
                                StopAllCoroutines();
                                jptextbox.text = currentlines[index];
                            }
                        }
                        else {
                            switch (playerdata.GetPlayerBot()) {
                                case 3:
                                    if (jppinktextbox.text == currentlines[index]) {
                                        NextPage();
                                    }
                                    else {
                                        StopAllCoroutines();
                                        jppinktextbox.text = currentlines[index];
                                    } 
                                break;
                                case 1:
                                    if (jpbluetextbox.text == currentlines[index]) {
                                        NextPage();
                                    }
                                    else {
                                        StopAllCoroutines();
                                        jpbluetextbox.text = currentlines[index];
                                    }
                                break;
                                case 2:
                                    if (jpyellowtextbox.text == currentlines[index]) {
                                        NextPage();
                                    }
                                    else {
                                        StopAllCoroutines();
                                        jpyellowtextbox.text = currentlines[index];
                                    }
                                break;
                            }
                        }
                    }   
                }
            }
        }
        
    }

    void NextPage() {
        if (index < currentlines.Length - 1) {
            index ++;
            if (language == 0) {
                textbox.text = string.Empty;
                bluetextbox.text = string.Empty;
                pinktextbox.text = string.Empty;
                yellowtextbox.text = string.Empty;
            }
            else {
                jptextbox.text = string.Empty;
                jpbluetextbox.text = string.Empty;
                jppinktextbox.text = string.Empty;
                jpyellowtextbox.text = string.Empty;
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
        jpbluetextbox.text = "";
        jppinktextbox.text = "";
        jpyellowtextbox.text = "";
        dialoguestarted = false;
    }

    IEnumerator TypeOutCharacters() {
        foreach (char c in currentlines[index].ToCharArray()) {
            if (language == 0) {
                //FOR ENGLISH DIALOGUE
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
                //FOR JAPANESE DIALOGUE
                if (whoistalking[index] == false) {
                    jptextbox.text += c;
                } else {
                    switch (playerdata.GetPlayerBot()) {
                        case 3:
                            jppinktextbox.text += c;
                        break;
                        case 1:
                            jpbluetextbox.text += c;
                        break;
                        case 2:
                            jpyellowtextbox.text += c;
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(textspeed);
        }
    }
}
