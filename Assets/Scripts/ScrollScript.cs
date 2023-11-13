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
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup HLG;

    public TMP_Text ItemName;
    public string[] ItemNames;

    bool isSnapped;
    float snapSpeed;
    public float snapForce;

    private int currentItem;


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
}
