using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class ShootingMinigameControler : MonoBehaviour
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
        timerinseconds = 1;

        gamestarted = false;
        speedtext.text = "Circle/s: " + respawntime;

        gameover = false;
        gameoverscreen.SetActive(false);
        endlessgameoverscreen.SetActive(false);

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
            RandomTargetSelect();
            timer = respawntime;
            ShrinkRespawnTime();
        }


        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        UpdateAmmoText();

        scoretext.text = "Score: " + score;
        if (score > hiscore)
        {
            hiscore = score;
            hiscoretext.text = "Hiscore: " + hiscore;
        }
    }

    void Fire()
    {
        if (currentClip > 0)
        {
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit = new RaycastHit();

            currentClip--;
            if (Physics.Raycast(cameraRay, out Hit))
            {
                if (Hit.collider.CompareTag("ShootTarget"))
                {
                    Debug.Log("hit target");

                    Hit.collider.gameObject.GetComponent<TargetScript>().AddScore();
                    //target.GetComponent<TargetScript>().AddScore();
                }
                else
                {
                    Debug.Log("missed");
                }
            }
        }
        if (currentClip == 0)
        {
            GameOver();
        }
    }
    void UpdateAmmoText()
    {
        AmmoCountText.text = $"{currentClip} / {maxClipSize}";
    }
    void ShrinkRespawnTime()
    {
        respawntime = respawntime - respawntime * 0.035f;
        speedtext.text = "Circle/s: " + respawntime;

        Debug.Log(respawntime);
    }

    void RandomTargetSelect()
    {
        int ItemIndex = (Random.Range(0, targetsArray.Length));
        int howMany = (Random.Range(0, 100));
        int ismovingtarget = (Random.Range(0, 100));

        if (howMany >= 60)
        {
            targetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
        }
        else if (howMany <= 20)
        {
            //want to make it so depending on the howMany value, different numbers of targets get activated at same time
            //Need to make ItemIndex generate multiple number for this case to work
            targetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
            targetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
            targetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
            targetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
        }
        else if (howMany > 20 && howMany < 60)
        {
            targetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
            targetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
        }
        else if (howMany > 60 && ismovingtarget >= 50)
        {
            movingtargetsArray[ItemIndex].GetComponent<TargetScript>().InitializeTargets();
        }
        

        ShrinkRespawnTime();
    }

    IEnumerator TimerText()
    {
        yield return new WaitForSeconds(0.75f);
        endlesscountdown.enabled = false;
        gamestarted = true;
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
        if (score >= requiredscore)
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
        SceneManager.LoadScene("Sharpshoot Minigame");
    }


    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
