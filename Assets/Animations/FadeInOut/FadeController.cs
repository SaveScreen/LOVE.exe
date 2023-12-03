using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    // make sure fade is turned on
    public GameObject FadeOBJ;
    public Animator LevelChangerComponent;
    public int levelToLoad;

    //public PlayerData playerdata;
    //public AudioSource buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        FadeOBJ.SetActive(true);
        LevelChangerComponent.Play("FadeIn");
    }

    public void GoToSettings()
    {
        FadeToLevel(10);
        //^^Add this to any function that loads a scene
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        LevelChangerComponent.SetTrigger("FadeOut");
        //buttonClick.Play();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
