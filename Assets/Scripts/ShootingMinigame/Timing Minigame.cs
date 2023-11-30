using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class TimingMinigame : MonoBehaviour
{
    Camera cam;
    public GameObject prefab;
    public TargetScript Script;
    public GameObject[] targetsArray;
    public GameObject[] movingtargetsArray;

    public GameObject playerdatacontainer;
    private PlayerData playerdata;

    public TextMeshProUGUI endlesscountdown;
    public TextMeshProUGUI speedtext;
    public TextMeshProUGUI AmmoCountText;

    public bool waitover;

    [Header("Timer Stuff")]
    public float timer; //Time in between circle spawning
    private float starttimer;
    private float respawntime;
    private int timerinseconds;
    [SerializeField] private float countdowntimer;

    [Header("Ammo Stuff")]
    public int currentClip, maxClipSize = 10;
    private bool gamestarted;
    [Header("Screens")]
    public GameObject game;
    public GameObject gameoverscreen;
    public TextMeshProUGUI gameovertext;
    public GameObject endlessgameoverscreen;
    public GameObject endlessgamewinscreen;
    public bool gameover;
    public bool didWin;
    [Header("Audio")]
    public AudioSource audioSource;
    public GameObject MusicPlayer;
    public AudioClip loseAudio;
    public AudioClip winAudio;

    [Header("Score")]
    public int score;
    public int requiredscore;
    private int hiscore;
    public TextMeshProUGUI hiscoretext;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI requiredscoretext;

    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        hiscore = playerdata.GetRhythmGameHiScore();
        scoretext.text = "Score: ";
        requiredscoretext.text = "score at least " + requiredscore + " to win!";

        cam = Camera.main;
        print(cam.name);
        TargetScript target = gameObject.GetComponent<TargetScript>();
        waitover = false;

        respawntime = timer;
        starttimer = timer;
        timerinseconds = 3;

        gamestarted = false;
        speedtext.text = "Circle/s: " + respawntime;

        gameover = false;
        gameoverscreen.SetActive(false);
        endlessgameoverscreen.SetActive(false);

        endlesscountdown.text = timerinseconds.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = respawntime;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        scoretext.text = "Score: " + score;
        if (score > hiscore)
        {
            hiscore = score;
            hiscoretext.text = "Hiscore: " + hiscore;
        }

        if (!gamestarted)
        {
            countdowntimer -= Time.deltaTime;
            endlesscountdown.text = timerinseconds.ToString();
            if (countdowntimer <= 3 && timerinseconds == 0)
            {
                timerinseconds = 3;
            }
            else if (countdowntimer < 2 && timerinseconds == 3)
            {
                timerinseconds = 2;
            }
            else if (countdowntimer < 1 && timerinseconds == 2)
            {
                timerinseconds = 1;
            }
            else if (countdowntimer < 0 && timerinseconds == 1)
            {
                countdowntimer = 0;
                endlesscountdown.text = "GO!";
                StartCoroutine(TimerText());
            }
        }
    }

    void Fire()
    {

           // Ray RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0, 0, 0));
            RaycastHit Hit = new RaycastHit();

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out Hit, 100.0f))
            {
                if (Hit.collider.CompareTag("ShootTarget"))
                {
                    Debug.Log("hit target");
                    didWin = true;
                    GameOver();
                }
                else
                {
                    Debug.Log("missed");
                    didWin = false;
                    GameOver();
                }
            }
        

    }

    IEnumerator TimerText()
    {
        yield return new WaitForSeconds(0.75f);
        endlesscountdown.enabled = false;
        gamestarted = true;
        targetsArray[0].GetComponent<TargetScript>().InitializeTargets();
        StopCoroutine(TimerText());
    }

    public void MinigameComplete()
    {
        gameover = true;
        didWin = true;
        Time.timeScale = 0;
        endlessgamewinscreen.SetActive(true);
        //SHOULD ONLY SHOW A CONTINUE BUTTON
    }

    public void GameOver()
    {
        if (didWin)
        {
            Debug.Log(didWin);
            Time.timeScale = 0;
            gameoverscreen.SetActive(true);
            gameovertext.text = "You win";
            MusicPlayer.SetActive(false);
            PlaySound(winAudio);
            gameover = true;
            didWin = true;
        }
        else
        {
            Time.timeScale = 0;
            gameover = true;
            gameoverscreen.SetActive(true);
            gameovertext.text = "You lose";
            MusicPlayer.SetActive(false);
            PlaySound(loseAudio);
            gameover = true;
            didWin = false;
        }
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Timing Minigame");
    }


    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
