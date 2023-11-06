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
    public bool gameover;
    public bool restart;
    private bool didWin;
    private int gamecount;

    // Start is called before the first frame update
    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();
        audioSource = GetComponent<AudioSource>();
        Generate();
        respawntime = timer;
        hiscore = playerdata.GetRhythmGameHiScore();
        scoretext.text = "Score: ";
        hiscoretext.text = "Hiscore: " + hiscore;
        speedtext.text = "Circle/s: " + respawntime;

        gamecount = playerdata.GetGameCount();

        switch (gamecount)
        {
            case 0:
                wintext.text = "Score at least 10 to pass!";
                break;
            case 1:
                wintext.text = "Score at least 30 to pass!";
                break;
            case 2:
                wintext.text = "Score at least 50 to pass!";
                break;
        }

        gameoverscreen.SetActive(false);
        restart = false;
        starttimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
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
        respawntime = respawntime - respawntime * 0.01f;
        speedtext.text = "Circle/s: " + respawntime;

        Debug.Log(respawntime);
    }
    public void PlaySound(AudioClip audio) {
        audioSource.PlayOneShot(audio);
    }

    public void GameOver() {
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
                if (score >= 30) {
                    didWin = true;
                }
                else {
                    didWin = false;
                }
            break;
            case 2:
                if (score >= 50) {
                    didWin = true;
                }
                else {
                    didWin = false;
                }
            break;
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
       /*
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
       */
    }
}
