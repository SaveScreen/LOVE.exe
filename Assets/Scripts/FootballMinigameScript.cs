using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FootballMinigameScript : MonoBehaviour
{
    public GameObject powermeter;
    public GameObject powertriangle;
    public GameObject regularbg;
    public GameObject christmasbg;
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
    private bool isEndlessMode;
    private bool isChristmas;
    private int footballGamesPlayed;
    public GameObject endlessgameoverscreen;
    public AudioSource audioSource;
    public AudioClip accurateSound;
    public AudioClip powerSound;
    public AudioClip fbWin;
    public AudioClip fbLose;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.timeScale);
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        ballScript = ball.GetComponent<BallScript>();

        gamestarted = false;
        countdowntimer.text = timerinseconds.ToString();
        powermeter.SetActive(false);
        accuracymeter.SetActive(false);
        restartbutton.SetActive(false);
        continuebutton.SetActive(false);
        endlessgameoverscreen.SetActive(false);
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
        isEndlessMode = playerdata.IsEndlessMode();
        isChristmas = playerdata.GetChristmasTime();

        if (isChristmas)
        {
            regularbg.SetActive(false);
            christmasbg.SetActive(true);
        }
        else if (!isChristmas)
        {
            regularbg.SetActive(true);
            christmasbg.SetActive(false);
        }
        

        if (isEndlessMode) {
            footballGamesPlayed = playerdata.GetFootballGamesPlayed();
            Debug.Log(footballGamesPlayed);
            powermeterspeed = 2;

            //Difficulty scaling
            if (footballGamesPlayed > 0) {
                powermeterspeed += 0.5f * footballGamesPlayed;
            }
        }

        click = inputs.FindAction("Player/MouseButton");
    }

    void OnEnable() {
        inputs.Enable();
    }

    void OnDisable() {
        inputs.Disable();
    }

    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
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
                PowerMeter();
            }
            //When the accuracy meter starts
            else
            {
                AccuracyMeter();
            }

        }
        //When the kick starts
        else if (gamestarted && kickingtime) {
            KickBall();
        }
    }

    void PowerMeter() {
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
                            PlaySound(accurateSound);
                            power = powertriangle.transform.localPosition.y;
                            //Debug.Log("Power is" + power);
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
                            PlaySound(accurateSound);
                            power = powertriangle.transform.localPosition.y;
                            enableaccuracy = true;
                            //Debug.Log("Power is " + power);
                        }
                        isgoingup = true;
                        
                    }
                }                
    }

    void AccuracyMeter() {
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
                            PlaySound(accurateSound);
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
                    PlaySound(accurateSound);
                    accuracy = accuracymeter.transform.position.x;
                            kickingtime = true;
                            Debug.Log("Accuracy is " + accuracy);
                        }
                        isgoingup = true;
                        //kickingtime = true;
                    }
                }
    }
    void KickBall() {
        
        if (donekicking == false) {
            Debug.Log("Kicking");
            
            if (power > -0.5f) {
                //Kick is high and center
                if (accuracy >= -0.75f && accuracy <= 0.75f) {
                    if (ballScript.animating == false) {
                        ballScript.BallAnimation(1);
                        StartCoroutine(AnimDelay());
                    }
                }
                //Kick is left
                else if (accuracy < -0.75f) {
                    if (ballScript.animating == false) {
                        ballScript.BallAnimation(3);
                        StartCoroutine(AnimDelay());
                    }
                }
                //Kick is right
                else if (accuracy > 0.75f) {
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
            if (!isEndlessMode) {
                switch (gamesPlayed)
                {
                    case 0:
                        if (power > -0.5f)
                        {
                            //Kick is high and center
                            if (accuracy >= -0.75f && accuracy <= 0.75f)
                            {
                                //THE KICK IS GOOD!
                                countdowntimer.enabled = true;
                                countdowntimer.text = "Kick is good :)";
                                didWin = true;
                            }
                            //Kick is wide left and right
                            else if (accuracy < -0.75f || accuracy > 0.75f)
                            {
                                //THE KICK IS WIDE LEFT!
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
            else {
                if (power > -0.5f)
                    {
                        //Kick is high and center
                        if (accuracy >= -0.75f && accuracy <= 0.75f)
                        {
                            //THE KICK IS GOOD!
                            countdowntimer.enabled = true;
                            countdowntimer.text = "Kick is good :)";
                            didWin = true;
                        }
                        //Kick is wide left and right
                        else if (accuracy < -0.75f || accuracy > 0.75f)
                        {
                            //THE KICK IS WIDE LEFT!
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
                endlessgameoverscreen.SetActive(true);
            }
            
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
        if (!isEndlessMode) {
            playerdata.UpdatePlayerDateScore(didWin);
            playerdata.IncreaseGameCount();
            if (didWin) {
                playerdata.WonGame();
            }
            else {
                playerdata.LostGame();
            }

            SceneManager.LoadScene("VisualNovel");
        }
        else {
            if (didWin) {
                playerdata.IncreaseFootballGamesPlayed();
                playerdata.IncreaseEndlessGamesPlayed();

                SceneManager.LoadScene("EndlessMode");
            }
            else {
                playerdata.DecreaseEndlessLives();
                
                SceneManager.LoadScene("EndlessMode");
            }
        }
        
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
