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
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            SceneManager.LoadScene("DataScene");
        }
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }

    public void GoToMenu() {
        bool playerSelected = playerdata.GetPlayerSelected();
        // If player is selected already, go straight to the next date.
        if (playerSelected) {
           playerdata.ResetPlayedGame();
          // SceneManager.LoadScene("VisualNovel");
            FadeToLevel(3);
        }
        else {
            //SceneManager.LoadScene("MenuScreen");
            FadeToLevel(2);
        }
        
    }


    public void GoToStore()
    {
        FadeToLevel(6);
       // SceneManager.LoadScene("StoreScene");
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
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
