using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class ScrollScript : MonoBehaviour
{
    /*
    public GameObject section; //Put only the Choose Outfit game object here
    public Scrollbar scroller;
    private float scrollval;
    public float xMinimum;
    public float xMaximum;
    */

    //Stuff Ethan Added
    public GameObject moneyContainer;
    public MONEYScript moneyData;
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup HLG;

    public TMP_Text ItemName;
    public string[] ItemNames;

    bool isSnapped;
    float snapSpeed;
    public float snapForce;

    public GameObject playerDataContainer;
    public PlayerData playerdata;

    private int currentItem;


    //Hopefully commenting this does nothing
    //public StoreSceneController storeController;


    private void Start()
    {
        isSnapped = false;
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
            if (contentPanel.localPosition.x == 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing)))
            {
                isSnapped = true;
            }
        }
        if (scrollRect.velocity.magnitude > 5)
        {
            ItemName.text = "_____";
            isSnapped = false;
            snapSpeed = 0;
        }
    }
    /*
    public void BuyButtonClicked()
    {
        int tempMon = 0;
        tempMon = moneyData.GetGAINZ();
        if (canAfford(tempMon)){
            if (!playerdata.getOutfitUnlocked(currentItem))
            {
                switch (currentItem)
                {
                    case 0:
                        moneyData.LoseMoney(500);
                        playerdata.UnlockOutfit(0);
                        break;
                    case 1:
                        moneyData.LoseMoney(500);
                        playerdata.UnlockOutfit(1);
                        break;
                    case 2:
                        moneyData.LoseMoney(500);
                        playerdata.UnlockOutfit(2);
                        break;
                    case 3:
                        moneyData.LoseMoney(1500);
                        playerdata.UnlockOutfit(3);
                        break;
                    case 4:
                        moneyData.LoseMoney(1500);
                        playerdata.UnlockOutfit(4);
                        break;
                    case 5:
                        moneyData.LoseMoney(1500);
                        playerdata.UnlockOutfit(5);
                        break;
                    case 6:
                        moneyData.LoseMoney(1500);
                        playerdata.UnlockOutfit(6);
                        break;
                }

                storeController.GetMoney();
            }
        }
        else if(!playerdata.getOutfitUnlocked(currentItem))
        {
            ItemName.text = "CANNOT AFFORD";
        }
        else
        {
            ItemName.text = "ALREADY UNLOCKED";
        }


    }
    */
    public bool canAfford(int money)
    {
        if(currentItem <= 2 && money >= 500) {
            return true;
        } 

        if(currentItem > 2 && money >= 1500) {
            return true;
        } 

        return false;
    }

    /*
    public void OutfitsScroll()
    {
        scrollval = scroller.value;
        section.transform.localPosition = new Vector2(Mathf.Lerp(xMinimum, xMaximum, scrollval), section.transform.localPosition.y);
    }
    */
}
