using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FootballMinigameScript : MonoBehaviour
{
    public GameObject powermeter;
    public GameObject powertriangle;
    private float trianglemaxposition;
    private float triangleminposition;
    private float accuracymaxposition;
    private float accuracyminposition;
    private bool isgoingup;
    private bool enableaccuracy;
    public GameObject accuracymeter;
    [SerializeField] private float timer;
    private int timerinseconds;
    public TextMeshProUGUI countdowntimer;
    public GameObject restartbutton;
    public GameObject continuebutton;
    private bool gamestarted;
    public float powermeterspeed;
    public InputActionAsset inputs;
    private InputAction click;
    private bool clicked;
    private bool kickingtime;
    private bool donekicking;
    private float accuracy;
    private float power;
    private int gamesPlayed;
    private bool didWin;
    public PlayerData playerdata;
    public GameObject playerdatacontainer;
    public GameObject ball;
    private BallScript ballScript;

    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        ballScript = ball.GetComponent<BallScript>();

        gamestarted = false;
        countdowntimer.text = timerinseconds.ToString();
        powermeter.SetActive(false);
        accuracymeter.SetActive(false);
        restartbutton.SetActive(false);
        continuebutton.SetActive(false);
        timerinseconds = 3;

        trianglemaxposition = 1.4f;
        triangleminposition = -1.4f;
        accuracymaxposition = 1.8f;
        accuracyminposition = -1.8f;
        isgoingup = true;
        enableaccuracy = false;
        kickingtime = false;
        donekicking = false;
        gamesPlayed = playerdata.GetGameCount();

        click = inputs.FindAction("Player/MouseButton");
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
        //Countdown begins
        if (!gamestarted) {
            timer -= Time.deltaTime;
            countdowntimer.text = timerinseconds.ToString();
            if (timer < 3 && timerinseconds == 0) {
                timerinseconds = 3;
            }
            else if (timer < 2 && timerinseconds == 3) {
                timerinseconds = 2;
            }
            else if (timer < 1 && timerinseconds == 2) {
                timerinseconds = 1;
            }
            else if (timer < 0 && timerinseconds == 1) {
                timer = 0;
                countdowntimer.text = "GO!";
                StartCoroutine(TimerText());
            }
        }
        //When the game begins after countdown
        else if (gamestarted && !kickingtime) {
            clicked = click.WasPressedThisFrame();
            
            if (!enableaccuracy)
            {
                switch (gamesPlayed)
                {
                    case 0:
                        powermeterspeed = 4;
                    break;
                    case 1:
                        powermeterspeed = 8;
                    break;
                    case 2:
                        powermeterspeed = 16;
                    break;
                }
                powermeter.SetActive(true);
                if (isgoingup)
                {
                    if (powertriangle.transform.localPosition.y < trianglemaxposition && !clicked)
                    {
                        powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x, Mathf.MoveTowards(powertriangle.transform.localPosition.y, trianglemaxposition, powermeterspeed * Time.deltaTime));
                    }
                    else
                    {
                        isgoingup = false;
                        
                        if (clicked) {
                            power = powertriangle.transform.localPosition.y;
                            Debug.Log("Power is" + power);
                            enableaccuracy = true;
                            isgoingup = true;
                        }
                    }
                }
                else
                {
                    if (powertriangle.transform.localPosition.y > triangleminposition && !clicked)
                    {
                        powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x, Mathf.MoveTowards(powertriangle.transform.localPosition.y, triangleminposition, powermeterspeed * Time.deltaTime));
                    }
                    else
                    {
                        if (clicked) {
                            power = powertriangle.transform.localPosition.y;
                            Debug.Log("Power is " + power);
                        } else {
                            power = powertriangle.transform.localPosition.y;
                            Debug.Log("Power is " + power);
                        }
                        isgoingup = true;
                        enableaccuracy = true;
                    }
                }

            }
            //When the accuracy meter starts
            else
            {
                powermeter.SetActive(false);
                accuracymeter.SetActive(true);
                if (isgoingup)
                {
                    if (accuracymeter.transform.position.x < accuracymaxposition && !clicked)
                    {
                        accuracymeter.transform.position = new Vector2(Mathf.MoveTowards(accuracymeter.transform.position.x, accuracymaxposition, powermeterspeed * Time.deltaTime), accuracymeter.transform.position.y);
                    }
                    else
                    {
                        isgoingup = false;
                        if (clicked) {
                            accuracy = accuracymeter.transform.position.x;
                            Debug.Log("Accuracy is " + accuracy);
                            isgoingup = true;
                            kickingtime = true;
                        }
                    }
                }
                else
                {
                    if (accuracymeter.transform.position.x > accuracyminposition && !clicked)
                    {
                        accuracymeter.transform.position = new Vector2(Mathf.MoveTowards(accuracymeter.transform.position.x, accuracyminposition, powermeterspeed * Time.deltaTime), accuracymeter.transform.position.y);
                    }
                    else
                    {
                        if (clicked) {
                            accuracy = accuracymeter.transform.position.x;
                            Debug.Log("Accuracy is " + accuracy);
                        } else {
                            accuracy = accuracymeter.transform.position.x;
                            Debug.Log("Accuracy is " + accuracy);
                        }
                        isgoingup = true;
                        kickingtime = true;
                    }
                }

            }

        }
        //When the kick starts
        else if (gamestarted && kickingtime) {
            KickBall();
        }
        
    }

    void KickBall() {
        
        if (donekicking == false) {
            Debug.Log("Kicking");
            
            if (power > -0.5f) {
                //Kick is high and center
                if (accuracy > -1.4f && accuracy < 1.4f) {
                    if (ballScript.animating == false) {
                        ballScript.BallAnimation(1);
                        StartCoroutine(AnimDelay());
                    }
                }
                //Kick is left
                else if (accuracy < -1.4f) {
                    if (ballScript.animating == false) {
                        ballScript.BallAnimation(3);
                        StartCoroutine(AnimDelay());
                    }
                }
                //Kick is right
                else if (accuracy > 1.4f) {
                    if (ballScript.animating == false) {
                        ballScript.BallAnimation(4);
                        StartCoroutine(AnimDelay());
                    }
                }
            }

            //Kick is too low
            else {
                if (ballScript.animating == false) {
                    ballScript.BallAnimation(2);
                    StartCoroutine(AnimDelay());
                }
                
            }
        }
        else {
            switch (gamesPlayed)
            {
                case 1:
                    if (power > -0.5f)
                    {
                        //Kick is high and center
                        if (accuracy > -1.4f && accuracy < 1.4f)
                        {
                            //THE KICK IS GOOD!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is good :)";
                            didWin = true;
                        }
                        //Kick is left
                        else if (accuracy < -1.4f)
                        {
                            //THE KICK IS WIDE LEFT!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is no good :(";
                            didWin = false;
                        }
                        //Kick is right
                        else if (accuracy > 1.4f)
                        {
                            //THE KICK IS WIDE RIGHT!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is no good :(";
                            didWin = false;
                        }
                    }

                    //Kick is too low
                    else
                    {
                        //THE KICK IS NO GOOD!
                        countdowntimer.enabled = true;
                        countdowntimer.text = "Kick is no good :(";
                        didWin = false;
                    }
                break;

                case 2:
                    if (power > -0.2f)
                    {
                        //Kick is high and center
                        if (accuracy > -1f && accuracy < 1f)
                        {
                            //THE KICK IS GOOD!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is good :)";
                            didWin = true;
                        }
                        //Kick is left
                        else if (accuracy < -1f)
                        {
                            //THE KICK IS WIDE LEFT!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is no good :(";
                            didWin = false;
                        }
                        //Kick is right
                        else if (accuracy > 1f)
                        {
                            //THE KICK IS WIDE RIGHT!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is no good :(";
                            didWin = false;
                        }
                    }

                    //Kick is too low
                    else
                    {
                        //THE KICK IS NO GOOD!
                        countdowntimer.enabled = true;
                        countdowntimer.text = "Kick is no good :(";
                        didWin = false;
                    }
                break;
                case 3:
                    if (power > 0.5f)
                    {
                        //Kick is high and center
                        if (accuracy > -0.5f && accuracy < 0.5f)
                        {
                            //THE KICK IS GOOD!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is good :)";
                            didWin = true;
                        }
                        //Kick is left
                        else if (accuracy < -0.5f)
                        {
                            //THE KICK IS WIDE LEFT!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is no good :(";
                            didWin = false;
                        }
                        //Kick is right
                        else if (accuracy > 0.5f)
                        {
                            //THE KICK IS WIDE RIGHT!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is no good :(";
                            didWin = false;
                        }
                    }

                    //Kick is too low
                    else
                    {
                        //THE KICK IS NO GOOD!
                        countdowntimer.enabled = true;
                        countdowntimer.text = "Kick is no good :(";
                        didWin = false;
                    }
                    break;
            }
            
            restartbutton.SetActive(true);
            continuebutton.SetActive(true);
        }
       
    }

    public void RestartGame() {
        gamestarted = false;
        countdowntimer.text = timerinseconds.ToString();
        timerinseconds = 3;
        powermeter.SetActive(false);
        accuracymeter.SetActive(false);
        restartbutton.SetActive(false);
        continuebutton.SetActive(false);
        isgoingup = true;
        enableaccuracy = false;
        kickingtime = false;
        donekicking = false;
        power = 0;
        accuracy = 0;
        timer = 3;
        
        powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x,triangleminposition);
        accuracymeter.transform.position = new Vector2(accuracyminposition, accuracymeter.transform.position.y);
    }
    public void Continue() {
        playerdata.UpdatePlayerDateScore(didWin);
        playerdata.IncreaseGameCount();
        if (didWin) {
            playerdata.WonGame();
        }
        else {
            playerdata.LostGame();
        }

        SceneManager.LoadScene("VisualNovel");
        gamestarted = false;
        countdowntimer.text = timerinseconds.ToString();
        timerinseconds = 3;
        powermeter.SetActive(false);
        accuracymeter.SetActive(false);
        restartbutton.SetActive(false);
        continuebutton.SetActive(false);
        isgoingup = true;
        enableaccuracy = false;
        kickingtime = false;
        donekicking = false;
        power = 0;
        accuracy = 0;
        timer = 3;
        
        powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x,triangleminposition);
        accuracymeter.transform.position = new Vector2(accuracyminposition, accuracymeter.transform.position.y);
    }

    IEnumerator TimerText() {
        yield return new WaitForSeconds(0.75f);
        countdowntimer.enabled = false;
        gamestarted = true;
        StopCoroutine(TimerText());
    }

    IEnumerator AnimDelay() {
        yield return new WaitForSeconds(3f);
        donekicking = true;
        ballScript.ResetBallAnimation();
        StopCoroutine(AnimDelay());
    }
}
