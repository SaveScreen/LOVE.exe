using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryScript : MonoBehaviour
{
    public GameObject JimPics;
    public GameObject JettPics;
    public GameObject MiscPics;

    public AudioSource buttonClick;

    public void Return()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    public void Credits()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Credits");
    }

    public void Gallery()
    {
        SceneManager.LoadScene("Gallery2");
        buttonClick.Play();
    }

    public void JimClick()
    {
        JimPics.SetActive(true);
        JettPics.SetActive(false);
        MiscPics.SetActive(false);
        buttonClick.Play();
    }
    public void JettClick()
    {
        JimPics.SetActive(false);
        JettPics.SetActive(true);
        MiscPics.SetActive(false);
        buttonClick.Play();
    }

    public void MiscClick()
    {
        JimPics.SetActive(false);
        JettPics.SetActive(false);
        MiscPics.SetActive(true);
        buttonClick.Play();
    }

}
