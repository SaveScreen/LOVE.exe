using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class AptSceneMenu : MonoBehaviour
{
    public GameObject moneyContainer;
    public MONEYScript moneyData;
    public TMP_Text moneyText;
    public GameObject player;
    private PlayerData playerdata;
    private int outfitSelect;

    //wear clothes in apartment
    public GameObject[] RoboWearingAPT;

    public Animator LevelChangerComponent;
    private int levelToLoad;

    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    // make sure fade is turned on
    public GameObject FadeOBJ;
    public GameObject tutTXT;

    //SFX
    public AudioSource buttonClick;

    void Start()
    {
        playerdata = player.GetComponent<PlayerData>();
        int howMuch;
        moneyData = moneyContainer.GetComponent<MONEYScript>();
        howMuch = moneyData.GetGAINZ();

        moneyText.SetText("Money: " + howMuch);

        foreach (GameObject obj in RoboWearingAPT)
        {
            obj.SetActive(false);
        }

        outfitSelect = playerdata.GetPlayerChibiOutfit();

        GameObject tempObj = RoboWearingAPT[outfitSelect];
        tempObj.SetActive(true);
        FadeOBJ.SetActive(true);

        if(PlayerData.firstLoad == true)
        {
            tutTXT.SetActive(true);
            moneyData.SetMoney(500);
        }
        else if (PlayerData.firstLoad == false)
        {
            tutTXT.SetActive(false);
        }

    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            SceneManager.LoadScene("DataScene");
        }
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }

    public void GoToMenu() {
        playerdata.ResetPlayedGame();
        FadeToLevel(2);
        
    }

    public void GoToEndless() {
        FadeToLevel(14);
    }

    public void GoToStore()
    {
        FadeToLevel(6);
        // SceneManager.LoadScene("StoreScene");
        PlayerData.firstLoad = false;


    }
    public void GoToCloset()
    {
        FadeToLevel(8);
      //  SceneManager.LoadScene("ClosetScene");
    }
    public void GoToSettings()
    {
        FadeToLevel(10);
        //SceneManager.LoadScene("SettingsScreen");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        LevelChangerComponent.SetTrigger("FadeOut");
        buttonClick.Play();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
