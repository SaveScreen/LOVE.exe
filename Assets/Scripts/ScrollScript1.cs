using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class ScrollScript1 : MonoBehaviour
{
    /*
    public GameObject section; //Put only the Choose Outfit game object here
    public Scrollbar scroller;
    private float scrollval;
    public float xMinimum;
    public float xMaximum;
    */

    //Stuff Ethan Added
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup HLG;

    //replaces name text w/ appropriate name
    public TMP_Text ItemName;
    public string[] ItemNames;

    //outfit images array
    public GameObject[] RoboWearing;

    bool isSnapped;
    float snapSpeed;
    public float snapForce;

    //Fun Effect
    public ParticleSystem OutfitClickedParticle;

    //Link to APT scene thru playerdata
    public GameObject playerDataContainer;
    public PlayerData playerdata;

    public int currentItem;

    private void Start()
    {
        isSnapped = false;

        foreach (GameObject obj in RoboWearing)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x / (sampleListItem.rect.width + HLG.spacing)));
        Debug.Log(currentItem);

        if (scrollRect.velocity.magnitude < 5 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(
                Mathf.MoveTowards(contentPanel.localPosition.x, 0 - currentItem * (sampleListItem.rect.width + HLG.spacing), snapSpeed),
                contentPanel.localPosition.y, 
                contentPanel.localPosition.z);
            ItemName.text = ItemNames[currentItem];
            RoboWearing[currentItem].SetActive(true);
            if (contentPanel.localPosition.x == 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing)))
            {
                isSnapped = true;
            }
        }
        if (scrollRect.velocity.magnitude > 5)
        {
            ItemName.text = "_____";
            RoboWearing[currentItem].SetActive(false);
            isSnapped = false;
            snapSpeed = 0;
        }
    }

    public void WearButtonClicked()
    {
        if(currentItem != 0 && playerdata.getOutfitUnlocked(currentItem - 1))
        {
            OutfitClickedParticle.Play();
            playerdata.SetPlayerChibiOutfit(currentItem);
        }
        else if(currentItem != 0)
        {
            ItemName.text = "NOT UNLOCKED";
        }
        else
        {
            OutfitClickedParticle.Play();
            playerdata.SetPlayerChibiOutfit(currentItem);
        }
    }

    /*
    public void OutfitsScroll()
    {
        scrollval = scroller.value;
        section.transform.localPosition = new Vector2(Mathf.Lerp(xMinimum, xMaximum, scrollval), section.transform.localPosition.y);
    }
    */
}
