using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AptSceneMenu : MonoBehaviour
{
    public void GoToMenu() {
        SceneManager.LoadScene("MenuScreen");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
