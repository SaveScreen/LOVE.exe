using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmMinigameScript : MonoBehaviour
{
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
    private AudioSource audioSource;
    public GameObject gameoverscreen;
    public GameObject endlessgameoverscreen;
    public GameObject endlessgamewinscreen;
    public bool gameover;
    public bool restart;
    private bool didWin;
    private int gamecount;
    private bool isEndlessMode;
    private int rhythmGamesPlayed;

    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        audioSource = GetComponent<AudioSource>();
        respawntime = timer;
        hiscore = playerdata.GetRhythmGameHiScore();
        scoretext.text = "Score: ";
        
        speedtext.text = "Circle/s: " + respawntime;
        timerinseconds = 3;

        gamecount = playerdata.GetGameCount();
        isEndlessMode = playerdata.IsEndlessMode();
        rhythmGamesPlayed = playerdata.GetRhythmGamesPlayed();


        if (!isEndlessMode) {
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
            hiscoretext.text = "Hiscore: " + hiscore;
        }
        else {
            switch (rhythmGamesPlayed) 
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
            hiscoretext.text = "";
        }

        gameoverscreen.SetActive(false);
        endlessgameoverscreen.SetActive(false);
        endlessgamewinscreen.SetActive(false);
        restart = false;
        starttimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEndlessMode) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            }
            else {
                Generate();
                timer = respawntime;
                ShrinkRespawnTime();
            }
            scoretext.text = "Score: " + score;

            if (score > hiscore) {
                hiscore = score;
                hiscoretext.text = "Hiscore: " + hiscore;
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
                if (timer > 0) {
                    timer -= Time.deltaTime;
                }
                else {
                    Generate();
                    timer = respawntime;
                    ShrinkRespawnTime();
                }
                scoretext.text = "Score: " + score;

                switch (rhythmGamesPlayed) {
                    case 0:
                        if (score >= 10) {
                            MinigameComplete();
                        }
                    break;
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
                    }
                    else {
                        didWin = false;
                    }
                break;
                case 1:
                    if (score >= 20) {
                        didWin = true;
                    }
                    else {
                        didWin = false;
                    }
                break;
                case 2:
                    if (score >= 30) {
                        didWin = true;
                    }
                    else {
                        didWin = false;
                    }
                break;
            }
        }
        else {
            Time.timeScale = 0;
            gameover = true;
            didWin = false;
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
        Generate();
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
                playerdata.IncreaseFootballGamesPlayed();

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
