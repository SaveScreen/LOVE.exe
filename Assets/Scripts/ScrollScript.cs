using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollScript : MonoBehaviour
{
    
    public GameObject section; //Put only the Choose Outfit game object here
    public Scrollbar scroller;
    private float scrollval;
    public float xMinimum;
    public float xMaximum;

    //Stuff Ethan Added
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup HLG;

    bool isSnapped;
    float snapSpeed;
    public float snapForce;

    public GameObject leftArrow;
    public GameObject rightArrow;

    private void Start()
    {
        isSnapped = false;
        leftArrow.SetActive(true);
        rightArrow.SetActive(true);
    }

    void Update()
    {
        int currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x / (sampleListItem.rect.width + HLG.spacing)));
        Debug.Log(currentItem);

        if (scrollRect.velocity.magnitude < 5 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(
                Mathf.MoveTowards(contentPanel.localPosition.x, 0 - currentItem * (sampleListItem.rect.width + HLG.spacing), snapSpeed),
                contentPanel.localPosition.y, 
                contentPanel.localPosition.z);
            if (contentPanel.localPosition.x == 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing)))
            {
                isSnapped = true;
            }
        }
        if (scrollRect.velocity.magnitude > 5)
        {
            isSnapped = false;
        }

        if (contentPanel.localPosition.x > 0)
        {
            leftArrow.SetActive(false);
            rightArrow.SetActive(true);
        }
        if (contentPanel.localPosition.x == 0)
        {
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        if (contentPanel.localPosition.x < 0)
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(true);
        }
    }

    public void OutfitsScroll()
    {
        scrollval = scroller.value;
        section.transform.localPosition = new Vector2(Mathf.Lerp(xMinimum, xMaximum, scrollval), section.transform.localPosition.y);
    }
}
