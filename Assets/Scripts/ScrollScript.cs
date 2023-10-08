using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D.Sprites;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollScript : MonoBehaviour
{
    
    public GameObject section; //Put only the Choose Outfit game object here
    public Scrollbar scroller;
    private float scrollval;
    
    public void OutfitsScroll() {
        scrollval = scroller.value;
        section.transform.localPosition = new Vector2(Mathf.Lerp(-1000,0,scrollval),section.transform.localPosition.y);
    }
}
