using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryScript : MonoBehaviour
{
    public GameObject JimPics;
    public GameObject JettPics;
    public GameObject FrillsPics;

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
        SceneManager.LoadScene("Gallery");
    }

    public void JimClick()
    {
        JimPics.SetActive(true);
        JettPics.SetActive(false);
        FrillsPics.SetActive(false);

    }
    public void JettClick()
    {
        JimPics.SetActive(false);
        JettPics.SetActive(true);
        FrillsPics.SetActive(false);
    }
    public void FrillsClick()
    {
        JimPics.SetActive(false);
        JettPics.SetActive(false);
        FrillsPics.SetActive(true);
    }

}