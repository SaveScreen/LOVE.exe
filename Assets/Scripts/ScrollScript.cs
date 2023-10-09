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
    
    public void OutfitsScroll() {
        scrollval = scroller.value;
        section.transform.localPosition = new Vector2(Mathf.Lerp(xMinimum,xMaximum,scrollval),section.transform.localPosition.y);
    }
}
