using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeGameController : MonoBehaviour
{
    public void GoToDate()
    {
        SceneManager.LoadScene("VisualNovel");
    }
    public void Restart()
    {
        SceneManager.LoadScene("SnakeMinigame");
    }
}
