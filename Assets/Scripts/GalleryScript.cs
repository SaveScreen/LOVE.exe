using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryScript : MonoBehaviour
{
    public GameObject JimPics;
    public GameObject JettPics;
    public GameObject MiscPics;

    public void Return()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Gallery()
    {
        SceneManager.LoadScene("Gallery2");
    }

    public void JimClick()
    {
        JimPics.SetActive(true);
        JettPics.SetActive(false);
        MiscPics.SetActive(false);
    }
    public void JettClick()
    {
        JimPics.SetActive(false);
        JettPics.SetActive(true);
        MiscPics.SetActive(false);
    }

    public void MiscClick()
    {
        JimPics.SetActive(false);
        JettPics.SetActive(false);
        MiscPics.SetActive(true);
    }

}
