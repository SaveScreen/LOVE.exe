using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterData : ScriptableObject
{

    //Dialogue Date 1
    public string[] angrylines;
    public string[] neutrallines;
    public string[] happylines;

    //Dialogue Date 2
    public string[] date2pregamelines;
    public string[] date2postgamelines;

    //Dialogue Date 3
    public string[] date3pregamelines;
    public string[] date3postgamelines;

    //Dialogue for games
    public string[] wongamelines;
    public string[] lostgamelines;
}
