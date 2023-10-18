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

    // Start is called before the first frame update
    void Start()
    {
        visNovelScript = visNovel.GetComponent<VisNovel>();
        click = inputs.FindAction("Player/MouseButton");

        index = 0;
        cutscene = true;
        textbox.text = "";
        dialoguestarted = false;
        dialoguefinished = false;

        
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
        }
    }

    IEnumerator TypeOutCharacters() {
        foreach (char c in currentlines[index].ToCharArray()) {
            textbox.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
}
