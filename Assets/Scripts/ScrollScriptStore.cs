using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.SceneManagement;

public class ScrollScriptStore : MonoBehaviour
{
    //Stuff Ethan Added
    public GameObject moneyContainer;
    public MONEYScript moneyData;
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup HLG;

    public TMP_Text ItemName;
    public string[] ItemNames;
    public TMP_Text ItemCost;
    public int[] ItemCosts;

    bool isSnapped;
    float snapSpeed;
    public float snapForce;

    public GameObject playerDataContainer;
    public PlayerData playerdata;

    private int currentItem;

    public StoreSceneController storeController;

    public TMP_Text moneyText;

    public ParticleSystem BuyParticle;

    //SFX

    public AudioSource StoreClothes;

    public FadeController fadecontroller;


    private void Start()
    {
        isSnapped = false;
        playerdata = playerDataContainer.GetComponent<PlayerData>();
        int howMuch;
        moneyData = moneyContainer.GetComponent<MONEYScript>();
        howMuch = moneyData.GetGAINZ();
        moneyText.SetText("Money: " + howMuch);
    }

    void Update()
    {
        currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x / (sampleListItem.rect.width + HLG.spacing)));
        Debug.Log(currentItem);

        if (scrollRect.velocity.magnitude < 20 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(
                Mathf.MoveTowards(contentPanel.localPosition.x, 0 - currentItem * (sampleListItem.rect.width + HLG.spacing), snapSpeed),
                contentPanel.localPosition.y,
                contentPanel.localPosition.z);
            ItemName.text = ItemNames[currentItem];
            ItemCost.text = "Cost: " + ItemCosts[currentItem];
            if (contentPanel.localPosition.x == 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing)))
            {
                isSnapped = true;
            }
        }
        if (scrollRect.velocity.magnitude > 20)
        {
            ItemName.text = "_____";
            ItemCost.text = "Cost:___";
            isSnapped = false;
            snapSpeed = 0;
        }
    }

    public void BuyButtonClicked()
    {
        int tempMon = 0;
        tempMon = moneyData.GetGAINZ();
        if (!playerdata.getOutfitUnlocked(currentItem))
        {
            if (canAfford(tempMon))
            {
                moneyData.LoseMoney(ItemCosts[currentItem]);
                playerdata.UnlockOutfit(currentItem);
                BuyParticle.Play();

                storeController.GetMoney();
                StoreClothes.Play();

                playerdata.SetPlayerChibiOutfit(currentItem);
                if (currentItem == 11)
                {
                    playerdata.SetChristmasTime(true);
                }
                else
                {
                    playerdata.SetChristmasTime(false);
                }

            }
            else
            {
                ItemName.text = "CANNOT AFFORD";
            }
        } else
        {
            ItemName.text = "ALREADY UNLOCKED";
        }

        playerdata = playerDataContainer.GetComponent<PlayerData>();
        int howMuch;
        moneyData = moneyContainer.GetComponent<MONEYScript>();
        howMuch = moneyData.GetGAINZ();
        moneyText.SetText("Money: " + howMuch);
    }

    public bool canAfford(int money)
    {
        if (money >= ItemCosts[currentItem])
        {
            return true;
        }

        return false;
    }

    public void ReturnToAPT()
    {
        playerdata.SaveGame();
        //SceneManager.LoadScene("AptScene");
        fadecontroller.FadeToLevel(1);
        //fadecontroller.OnFadeComplete();
        
    }

    /*
    public void OutfitsScroll()
    {
        scrollval = scroller.value;
        section.transform.localPosition = new Vector2(Mathf.Lerp(xMinimum, xMaximum, scrollval), section.transform.localPosition.y);
    }
    */
}
