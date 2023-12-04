using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmMinigameScript : MonoBehaviour
{
    public GameObject regularbg;
    public GameObject christmasbg;
    public GameObject prefab;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI speedtext;
    public TextMeshProUGUI wintext;
    public TextMeshProUGUI hiscoretext;
    public TextMeshProUGUI endlesscountdown;
    private int timerinseconds;
    [SerializeField] private float countdowntimer;
    private bool gamestarted;
    public GameObject playerdatacontainer;
    private PlayerData playerdata;
    //public int amount;
    public float spawnradius;
    public float timer; //Time in between circle spawning
    private float starttimer;
    private float respawntime;
    public int score;
    private int hiscore;
    public AudioClip winAudio;
    public AudioClip loseAudio;
    public GameObject MusicPlayer;
    private AudioSource audioSource;
    public GameObject gameoverscreen;
    public GameObject endlessgameoverscreen;
    public GameObject endlessgamewinscreen;
    public bool gameover;
    public bool restart;
    private bool didWin;
    private int gamecount;
    private bool isEndlessMode;
    private bool isChristmas;
    private int rhythmGamesPlayed;
    private int potentialscore;
    private bool firstspawn;
    private bool theresaCircle = false;

    private Camera maincamera;
    [SerializeField] private CircleScript circlescript;

    // Start is called before the first frame update
    void Start()
    {
        maincamera = FindObjectOfType<Camera>();
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        audioSource = GetComponent<AudioSource>();
        respawntime = timer;
        hiscore = playerdata.GetRhythmGameHiScore();
        scoretext.text = "Score: ";
        
        speedtext.text = "Circle/s: " + respawntime;
        timerinseconds = 3;

        isEndlessMode = playerdata.IsEndlessMode();
        isChristmas = playerdata.GetChristmasTime();

        if (isChristmas)
        {
            regularbg.SetActive(false);
            christmasbg.SetActive(true);
        }
        else
        {
            regularbg.SetActive(true);
            christmasbg.SetActive(false);
        }


        if (!isEndlessMode) {
            gamecount = playerdata.GetGameCount();

            switch (gamecount)
            {
                case 0:
                    wintext.text = "Score at least 10 to pass!";
                    break;
                case 1:
                    wintext.text = "Score at least 20 to pass!";
                    break;
                case 2:
                    wintext.text = "Score at least 30 to pass!";
                    break;
            }

            Generate();
            theresaCircle = true;
            endlesscountdown.text = "";
            hiscoretext.text = "Hiscore: " + hiscore;
        }
        else {
            rhythmGamesPlayed = playerdata.GetRhythmGamesPlayed();
            Debug.Log(rhythmGamesPlayed);
            potentialscore = 10;
            gamestarted = false;
            gameover = false;
            firstspawn = false;
            
            //Difficulty scaling
            if (rhythmGamesPlayed > 0) {
                potentialscore += 5 * rhythmGamesPlayed;
            }
            
            wintext.text = "Score at least " + potentialscore + " to pass!";
            hiscoretext.text = "";
        }

        gameoverscreen.SetActive(false);
        endlessgameoverscreen.SetActive(false);
        endlessgamewinscreen.SetActive(false);
        restart = false;
        starttimer = timer;
        MusicPlayer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        circlescript = FindObjectOfType<CircleScript>();

        if (Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = maincamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit = new RaycastHit();

            if (Physics.Raycast(cameraRay, out Hit))
            {
                if (Hit.collider.CompareTag("ShootTarget"))
                {
                    Debug.Log("Circle Hit");
                    circlescript.AddScore();
                    theresaCircle = false;
                }
                else
                {
                    Debug.Log("Missed");
                }
            }
        }





        if (!isEndlessMode) {
            if(!theresaCircle)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {
                    Generate();
                    theresaCircle = true;
                    timer = respawntime;
                    ShrinkRespawnTime();
                }
                scoretext.text = "Score: " + score;

                if (score > hiscore)
                {
                    hiscore = score;
                    hiscoretext.text = "Hiscore: " + hiscore;
                }
            }
        }
        else {
            if (!gamestarted) {
                countdowntimer -= Time.deltaTime;
                endlesscountdown.text = timerinseconds.ToString();
                if (countdowntimer < 3 && timerinseconds == 0) {
                    timerinseconds = 3;
                }
                else if (countdowntimer < 2 && timerinseconds == 3) {
                    timerinseconds = 2;
                }
                else if (countdowntimer < 1 && timerinseconds == 2) {
                    timerinseconds = 1;
                }
                else if (countdowntimer < 0 && timerinseconds == 1) {
                    countdowntimer = 0;
                    endlesscountdown.text = "GO!";
                    StartCoroutine(TimerText());
                }
            }
            else {
                if (!firstspawn) {
                    Generate();
                    theresaCircle = true;
                    firstspawn = true;
                }
                else {
                    if (timer > 0) {
                    timer -= Time.deltaTime;
                    }
                    else {
                        Generate();
                        theresaCircle = true;
                        timer = respawntime;
                        ShrinkRespawnTime();
                    }
                    scoretext.text = "Score: " + score;

                    if (score >= potentialscore) {
                        if (!gameover) {
                            MusicPlayer.SetActive(false);
                            PlaySound(winAudio);
                            MinigameComplete();
                        }
                    }
                }
                
            }
        } 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Generate() {
        Vector3 randomPosition = Random.insideUnitCircle * spawnradius;

        Instantiate(prefab, randomPosition, Quaternion.identity);
        
    }
    void ShrinkRespawnTime(){
        respawntime = respawntime - respawntime * 0.035f;
        speedtext.text = "Circle/s: " + respawntime;

        Debug.Log(respawntime);
    }
    public void PlaySound(AudioClip audio) {
        audioSource.PlayOneShot(audio);
    }

    public void MinigameComplete() {
        gameover = true;
        didWin = true;
        Time.timeScale = 0;
        endlessgamewinscreen.SetActive(true);
        //SHOULD ONLY SHOW A CONTINUE BUTTON
    }

    public void GameOver() {
        if (!isEndlessMode) {
            Time.timeScale = 0;
            gameover = true;
            gameoverscreen.SetActive(true);

            switch (gamecount) {
                case 0:
                    if (score >= 10) {
                        didWin = true;
                        MusicPlayer.SetActive(false);
                        PlaySound(winAudio);
                    }
                    else {
                        didWin = false;
                        MusicPlayer.SetActive(false);
                        PlaySound(loseAudio);
                    }
                break;
                case 1:
                    if (score >= 20) {
                        didWin = true;
                        MusicPlayer.SetActive(false);
                        PlaySound(winAudio);
                    }
                    else {
                        didWin = false;
                        MusicPlayer.SetActive(false);
                        PlaySound(loseAudio);
                    }
                break;
                case 2:
                    if (score >= 30) {
                        didWin = true;
                        MusicPlayer.SetActive(false);
                        PlaySound(winAudio);
                    }
                    else {
                        didWin = false;
                        MusicPlayer.SetActive(false);
                        PlaySound(loseAudio);
                    }
                break;
            }
        }
        else {
            MusicPlayer.SetActive(false);
            PlaySound(loseAudio);
            Time.timeScale = 0;
            gameover = true;
            didWin = false;
            Debug.Log(didWin);
            endlessgameoverscreen.SetActive(true);
        }
        
    }

    public void Restart() {
        Time.timeScale = 1;
        gameover = false;
        restart = true;
        score = 0;
        respawntime = starttimer;
        timer = respawntime;
        scoretext.text = "Score: " + score;
        speedtext.text = "Circle/s: " + respawntime;
        gameoverscreen.SetActive(false);
        MusicPlayer.SetActive(true);
        Generate();
        theresaCircle = true;
        SceneManager.LoadScene("RhythmMinigame");
    }

    public void Continue() {
        if (!isEndlessMode) {
            playerdata.UpdatePlayerDateScore(didWin);
            if (hiscore > playerdata.GetRhythmGameHiScore()) {
                playerdata.NewRhythmGameHiScore(hiscore);
            }
            playerdata.IncreaseGameCount();

            if (didWin) {
                playerdata.WonGame();
            }
            else {
                playerdata.LostGame();
            }

            SceneManager.LoadScene("VisualNovel");
        
            Time.timeScale = 1;
        }
        else {
            if (didWin) {
                playerdata.IncreaseEndlessGamesPlayed();
                playerdata.IncreaseRhythmGamesPlayed();
                SceneManager.LoadScene("EndlessMode");
                Time.timeScale = 1;
                
            }
            else {
                playerdata.DecreaseEndlessLives();

                SceneManager.LoadScene("EndlessMode");
                Time.timeScale = 1;
                
            }
            
        }

    }

    IEnumerator TimerText() {
        yield return new WaitForSeconds(0.75f);
        endlesscountdown.enabled = false;
        gamestarted = true;
        StopCoroutine(TimerText());
    }
}
