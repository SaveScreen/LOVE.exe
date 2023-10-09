using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class VisNovel : MonoBehaviour
{
    public GameObject Date1Choice;
    public GameObject Date2Choice;
    public GameObject Date3Choice;
    public GameObject playerdatacontainer;
    public PlayerData playerdata;
    //public Transform datePref;
    //public GameObject datePrefObj;
    public GameObject Angry1;
    public GameObject Neutral1;
    public GameObject Happy1;
    public GameObject Angry2;
    public GameObject Neutral2;
    public GameObject Happy2;
    public GameObject Angry3;
    public GameObject Neutral3;
    public GameObject Happy3;

    void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();


        switch (playerdata.GetPlayerDate())
        {
            case 1:
                Date1Pref();
                break;
            case 2:
                Date2Pref();
                break;
            case 3:
                Date3Pref();
                break;
            default:
                break;

        }


    }

    public void Date1Pref()
    {
        Date1Choice.SetActive(true);
        if (playerdata.GetPlayerBot() == 2 && playerdata.GetPlayerOutfit() == 1)
        {
            Happy1.SetActive(true);
        }
        else if (playerdata.GetPlayerBot() == 1 && playerdata.GetPlayerOutfit() == 1 || playerdata.GetPlayerBot() == 2 && playerdata.GetPlayerOutfit() != 1)
        {
            Neutral1.SetActive(true);
        }
        else
        {
            Angry1.SetActive(true);
        }

        /*
        if (playerdata.GetPlayerBot() == 2 && playerdata.GetPlayerOutfit() == 1)
        {
            datePrefObj = transform.Find("Date1Happy").gameObject;
            datePrefObj.SetActive(true);
        } else if (playerdata.GetPlayerBot() == 1 && playerdata.GetPlayerOutfit() == 1 || playerdata.GetPlayerBot() == 2 && playerdata.GetPlayerOutfit() != 1)
        {
            datePrefObj = transform.Find("Date1Neutral").gameObject;
            datePrefObj.SetActive(true);
        } else
        {
            datePrefObj = transform.Find("Date1Angry").gameObject;
            datePrefObj.SetActive(true);
        }
        */



    }

    public void Date2Pref()
    {
        Date2Choice.SetActive(true);
        if (playerdata.GetPlayerOutfit() == 3)
        {
            Happy2.SetActive(true);
        }
        else if (playerdata.GetPlayerOutfit() != 3)
        {
            Angry2.SetActive(true);
        }
        else
        {
            Neutral2.SetActive(true);
        }
    }

    public void Date3Pref()
    {
        Date3Choice.SetActive(true);
        if (playerdata.GetPlayerBot() == 1 && playerdata.GetPlayerOutfit() == 2)
        {
            Happy3.SetActive(true);
        }
        else if (playerdata.GetPlayerBot() == 2 && playerdata.GetPlayerOutfit() == 2 || playerdata.GetPlayerBot() == 1 && playerdata.GetPlayerOutfit() != 2)
        {
            Neutral3.SetActive(true);
        }
        else
        {
            Angry3.SetActive(true);
        }

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
