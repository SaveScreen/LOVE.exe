using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessModeController : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI hiscoretext;
    public GameObject[] livesobjects;
    public GameObject startEndlessMode;
    public GameObject inEndlessMode;
    public GameObject gameOverEndlessMode;
    //public GameObject quitEndlessMode;
    public GameObject playerDataObject;
    private PlayerData playerData;
    private bool isEndlessMode;
    private int gamesPlayed;
    private int lives;
    private int currentScore;
    private int hiscore;
    private bool gameover;
    private bool newhiscore;

    // Start is called before the first frame update
    void Start()
    {
        playerData = playerDataObject.GetComponent<PlayerData>();

        gamesPlayed = playerData.GetEndlessGamesPlayed();
        lives = playerData.GetEndlessLives();
        hiscore = playerData.GetEndlessHiScore();
        isEndlessMode = playerData.IsEndlessMode();
        gameover = false;
        newhiscore = false;

        currentScore = gamesPlayed;

        scoretext.text = "Score: " + currentScore;
        hiscoretext.text = "Hiscore: " + hiscore;

        Debug.Log("Endless Lives " + lives);

        if (isEndlessMode) {
            startEndlessMode.SetActive(false);
            //quitEndlessMode.SetActive(false);

            if (currentScore > hiscore) {
                playerData.NewEndlessHiScore(currentScore);
                hiscoretext.text = "Hiscore: " + currentScore;
                newhiscore = true;
            }

            if (lives == 3) {
                livesobjects[0].SetActive(true);
                livesobjects[1].SetActive(true);
                livesobjects[2].SetActive(true);
                inEndlessMode.SetActive(true);
                gameOverEndlessMode.SetActive(false);
            }
            else if (lives == 2) {
                livesobjects[0].SetActive(false);
                livesobjects[1].SetActive(true);
                livesobjects[2].SetActive(true);
                inEndlessMode.SetActive(true);
                gameOverEndlessMode.SetActive(false);
            }
            else if (lives == 1) {
                livesobjects[0].SetActive(false);
                livesobjects[1].SetActive(false);
                livesobjects[2].SetActive(true);
                inEndlessMode.SetActive(true);
                gameOverEndlessMode.SetActive(false);
            }
            else if (lives == 0) {
                livesobjects[0].SetActive(false);
                livesobjects[1].SetActive(false);
                livesobjects[2].SetActive(false);
                inEndlessMode.SetActive(false);
                gameOverEndlessMode.SetActive(true);
                gameover = true;
            }
        }
        else {
            startEndlessMode.SetActive(true);
            inEndlessMode.SetActive(false);
            gameOverEndlessMode.SetActive(false);
            //quitEndlessMode.SetActive(false);
        }
        
    }

    public void QuitEndlessMode() {
        playerData.ResetEndlessGamesPlayed();
        playerData.ResetSnakeGamesPlayed();
        playerData.ResetFootballGamesPlayed();
        playerData.ResetEndlessGamesPlayed();
        playerData.EndEndlessMode();

        if (gameover) {
            if (newhiscore) {
                playerData.SaveGame();
                Debug.Log("New hi score");
            }
        }

        SceneManager.LoadScene("AptScene");
    }

    public void StartEndlessMode() {
        int rand = Random.Range(0,3);
        switch (rand) {
            case 0:
                playerData.StartEndlessMode();
                SceneManager.LoadScene("FootballMinigame");
            break;
            case 1:
                playerData.StartEndlessMode();
                SceneManager.LoadScene("SnakeMinigame");
            break;
            case 2:
                playerData.StartEndlessMode();
                SceneManager.LoadScene("RhythmMinigame");
            break;
        }
    }

    public void ContinueEndlessMode() {
        int rand = Random.Range(0,3);
        switch (rand) {
            case 0:
                
                SceneManager.LoadScene("FootballMinigame");
            break;
            case 1:
                
                SceneManager.LoadScene("SnakeMinigame");
            break;
            case 2:
                
                SceneManager.LoadScene("RhythmMinigame");
            break;
        }
    }

    public void RestartEndless() {
        int rand = Random.Range(0,3);
        switch (rand) {
            case 0:
                gameover = false;
                if (newhiscore) {
                    playerData.SaveGame();
                    newhiscore = false;
                }
                playerData.ResetEndlessGamesPlayed();
                playerData.ResetSnakeGamesPlayed();
                playerData.ResetFootballGamesPlayed();
                playerData.ResetEndlessGamesPlayed();
                playerData.StartEndlessMode();
                SceneManager.LoadScene("FootballMinigame");
            break;
            case 1:
                gameover = false;
                if (newhiscore) {
                    playerData.SaveGame();
                    newhiscore = false;
                }
                playerData.ResetEndlessGamesPlayed();
                playerData.ResetSnakeGamesPlayed();
                playerData.ResetFootballGamesPlayed();
                playerData.ResetEndlessGamesPlayed();
                playerData.StartEndlessMode();
                SceneManager.LoadScene("SnakeMinigame");
            break;
            case 2:
                gameover = false;
                if (newhiscore) {
                    playerData.SaveGame();
                    newhiscore = false;
                }
                playerData.ResetEndlessGamesPlayed();
                playerData.ResetSnakeGamesPlayed();
                playerData.ResetFootballGamesPlayed();
                playerData.ResetEndlessGamesPlayed();
                playerData.StartEndlessMode();
                SceneManager.LoadScene("RhythmMinigame");
            break;
        }
    }
}
