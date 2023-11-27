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

    //*********************************************************************************

    [Header ("Christmas Dialogue")]
    //Dialogue Date 1
    public string[] christmasangrylines;
    public bool[] christmasalWhoistalking;
    public string[] christmasneutrallines;
    public bool[] christmasnlWhoistalking;
    public string[] christmashappylines;
    public bool[] christmashlWhoistalking;

    //Dialogue Date 2
    public string[] christmasdate2pregamelines;
    public bool[] christmasdate2preWhoistalking;
    public string[] christmasdate2postgamelines;
    public bool[] christmasdate2postWhoistalking;

    //Dialogue Date 3
    public string[] christmasdate3pregamelines;
    public bool[] christmasdate3preWhoistalking;
    public string[] christmasdate3postgamelines;
    public bool[] christmasdate3postWhoistalking;

    //Dialogue for games
    public string[] christmaswongamelines;
    public bool[] christmaswongameWhoistalking;
    public string[] christmaslostgamelines;
    public bool[] christmaslostgameWhoistalking;
    
    //*********************************************************************************

    //IF BOOL IS TRUE, THE PLAYER BOT IS TALKING

    public int[] minigameOrder;
    
    //SET 3 INTS, 0 MEANS NOT BEEN SET YET, 1: FOOTBALL MINIGAME, 2: ZOMBIE MINIGAME, 3: RHYTHM MINIGAME

}
