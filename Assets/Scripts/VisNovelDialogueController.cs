using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class VisNovelDialogueController : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    private string[] currentlines;
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

    // Start is called before the first frame update
    void Start()
    {
        visNovelScript = visNovel.GetComponent<VisNovel>();
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        click = inputs.FindAction("Player/MouseButton");

        index = 0;
        cutscene = true;
        textbox.text = "";
        dialoguestarted = false;
        dialoguefinished = false;
        gamecount = playerdata.GetGameCount();
        wonlastgame = playerdata.GetWin();
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
        if (dialoguestarted == false) {
            switch (gamecount) {
                case 0:
                    switch (visNovelScript.dateref) {
                        //Cowboy
                        case 1:
                            switch (visNovelScript.datemoodref) {
                                case 1:
                                    currentlines = cowboyangrylines;
                                break;
                                case 2:
                                    currentlines = cowboyneutrallines;
                                break;

                                case 3:
                                    currentlines = cowboyhappylines;
                                break;
                            }
                        break;
                        //Goth
                        case 2:
                            switch (visNovelScript.datemoodref) {
                                case 1:
                                    currentlines = gothangrylines;
                                break;
                                case 2:
                                    currentlines = gothneutrallines;
                                break;

                                case 3:
                                    currentlines = gothhappylines;
                                break;
                            }
                        break;
                        //Fancy
                        case 3:
                            switch (visNovelScript.datemoodref) {
                                case 1:
                                    currentlines = fancyangrylines;
                                break;
                                case 2:
                                    currentlines = fancyneutrallines;
                                break;

                                case 3:
                                    currentlines = fancyhappylines;
                                break;
                            }
                        break;
                    }
                break;
                case 1:
                    switch (visNovelScript.dateref) {
                        //Cowboy
                        case 1:
                            if (wonlastgame) {
                                currentlines = cowboywinlines;
                            }
                            else {
                                currentlines = cowboyloselines;
                            }
                        break;
                        //Goth
                        case 2:
                            if (wonlastgame) {
                                currentlines = gothwinlines;
                            }
                            else {
                                currentlines = gothloselines;
                            }
                        break;
                        //Fancy
                        case 3:
                            if (wonlastgame) {
                                currentlines = fancywinlines;
                            }
                            else {
                                currentlines = fancyloselines;
                            }
                        break;
                    }
                break;
                case 2:
                    switch (visNovelScript.dateref) {
                        //Cowboy
                        case 1:
                            if (wonlastgame) {
                                currentlines = cowboywinlines;
                            }
                            else {
                                currentlines = cowboyloselines;
                            }
                        break;
                        //Goth
                        case 2:
                            if (wonlastgame) {
                                currentlines = gothwinlines;
                            }
                            else {
                                currentlines = gothloselines;
                            }
                        break;
                        //Fancy
                        case 3:
                            if (wonlastgame) {
                                currentlines = fancywinlines;
                            }
                            else {
                                currentlines = fancyloselines;
                            }
                        break;
                    }
                break;
                
                case 3:
                    switch (visNovelScript.dateref) {
                        //Cowboy
                        case 1:
                            if (wonlastgame) {
                                currentlines = cowboywinlines;
                            }
                            else {
                                currentlines = cowboyloselines;
                            }
                        break;
                        //Goth
                        case 2:
                            if (wonlastgame) {
                                currentlines = gothwinlines;
                            }
                            else {
                                currentlines = gothloselines;
                            }
                        break;
                        //Fancy
                        case 3:
                            if (wonlastgame) {
                                currentlines = fancywinlines;
                            }
                            else {
                                currentlines = fancyloselines;
                            }
                        break;
                    }
                break;
                case 4:
                    switch (visNovelScript.dateref) {
                        //Cowboy
                        case 1:
                            if (wonlastgame) {
                                currentlines = cowboywinlines;
                            }
                            else {
                                currentlines = cowboyloselines;
                            }
                        break;
                        //Goth
                        case 2:
                            if (wonlastgame) {
                                currentlines = gothwinlines;
                            }
                            else {
                                currentlines = gothloselines;
                            }
                        break;
                        //Fancy
                        case 3:
                            if (wonlastgame) {
                                currentlines = fancywinlines;
                            }
                            else {
                                currentlines = fancyloselines;
                            }
                        break;
                    }
                break;
            }
            StartCoroutine(TypeOutCharacters());
            dialoguestarted = true;
        }
        else {
            clicked = click.WasPressedThisFrame();
            if (cutscene) {
                if (clicked) {
                    if (textbox.text == currentlines[index]) {
                        NextPage();
                    }
                    else {
                        StopAllCoroutines();
                        textbox.text = currentlines[index];
                    }
                }
            }
        }
        
    }

    void NextPage() {
        if (index < currentlines.Length - 1) {
            index ++;
            textbox.text = string.Empty;
            StartCoroutine(TypeOutCharacters());
        }
        else {
            dialoguefinished = true;
            index = 0;
        }
    }

    IEnumerator TypeOutCharacters() {
        foreach (char c in currentlines[index].ToCharArray()) {
            textbox.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
}
