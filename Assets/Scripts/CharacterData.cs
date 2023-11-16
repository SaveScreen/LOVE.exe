using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterData : ScriptableObject
{

    //Dialogue Date 1
    public string[] angrylines;
    public bool[] alWhoistalking;
    public string[] neutrallines;
    public bool[] nlWhoistalking;
    public string[] happylines;
    public bool[] hlWhoistalking;

    //Dialogue Date 2
    public string[] date2pregamelines;
    public bool[] date2preWhoistalking;
    public string[] date2postgamelines;
    public bool[] date2postWhoistalking;

    //Dialogue Date 3
    public string[] date3pregamelines;
    public bool[] date3preWhoistalking;
    public string[] date3postgamelines;
    public bool[] date3postWhoistalking;

    //Dialogue for games
    public string[] wongamelines;
    public bool[] wongameWhoistalking;
    public string[] lostgamelines;
    public bool[] lostgameWhoistalking;

    //IF BOOL IS TRUE, THE PLAYER BOT IS TALKING

    public int[] minigameOrder;
    
    //SET 3 INTS, 0 MEANS NOT BEEN SET YET, 1: FOOTBALL MINIGAME, 2: ZOMBIE MINIGAME, 3: RHYTHM MINIGAME

}
