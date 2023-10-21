using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhythmMinigameScript : MonoBehaviour
{
    public GameObject prefab;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI speedtext;
    //public int amount;
    public float spawnradius;
    public float timer; //Time in between circle spawning
    private float starttimer;
    private float respawntime;
    public float score;
    private AudioSource audioSource;
    public GameObject gameoverscreen;
    public bool gameover;
    public bool restart;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Generate();
        respawntime = timer;
        scoretext.text = "Score: ";
        speedtext.text = "Circle/s: " + respawntime;

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

    public void GameOver() {
        Time.timeScale = 0;
        gameover = true;
        gameoverscreen.SetActive(true);
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
}
