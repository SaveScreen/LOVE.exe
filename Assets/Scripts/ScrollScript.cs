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
    
    public GameObject outfits; //Put only the Choose Outfit game object here
    public GameObject dates; //Put only the Choose Date game object here
    public Scrollbar outfitsscrollbar;
    public Scrollbar datesscrollbar;
    private float outfitsscrollval;
    private float datesscrollval;
    
    public void OutfitsScroll() {
        outfitsscrollval = outfitsscrollbar.value;
        outfits.transform.localPosition = new Vector2(Mathf.Lerp(-1000,0,outfitsscrollval),outfits.transform.localPosition.y);
    }

    public void DatesScroll() {
        datesscrollval = datesscrollbar.value;
        dates.transform.localPosition = new Vector2(Mathf.Lerp(-1000,0,datesscrollval),dates.transform.localPosition.y);
    }
}
