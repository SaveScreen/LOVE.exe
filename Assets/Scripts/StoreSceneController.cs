using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreSceneController : MonoBehaviour
{
    public void GoToApartment()
    {
        SceneManager.LoadScene("AptScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
