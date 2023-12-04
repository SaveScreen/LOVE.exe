using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Animator LevelChangerComponent;
    private int levelToLoad;
    public GameObject player;
    public AudioSource StartScreenSound;

    //Scrolling BG
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    //Holoday ad
    public GameObject Ad;

    private void Start()
    {
        PlayerData playerdata = player.GetComponent<PlayerData>();
        playerdata.InitialFileCheck();
    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
         {
            Destroy(Ad);
            
        }

        if (Input.GetMouseButtonDown(0) && Ad == null)
        {

            FadeToLevel(1);
            StartScreenSound.Play();
        }

        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }

    public void FadeToNextLevel (int levelIndex)
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        LevelChangerComponent.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        PlayerData playerdata = player.GetComponent<PlayerData>();
        //playerdata.InitialFileCheck();
        bool playerSelected = playerdata.GetPlayerSelected();
        if (playerSelected) {
            playerdata.LoadGame();
            SceneManager.LoadScene("AptScene");
        }
        else {
            playerdata.NewGame();
            SceneManager.LoadScene("RoboSelect 1");
        }
        
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene("MenuScreen");
    }
}
