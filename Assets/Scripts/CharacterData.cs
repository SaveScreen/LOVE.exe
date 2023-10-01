using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class CharacterData : ScriptableObject
{
    //What outfit do they like?
    public int outfitPreference;
    //Who do they prefer when dating?
    public int datePreference;
    //How harsh are they?
    public int judgement;
}
