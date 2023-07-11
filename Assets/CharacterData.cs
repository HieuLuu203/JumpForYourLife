using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character" )]
public class CharacterData : ScriptableObject
{
    public string characterName;
    private int ID;
    public Sprite sprite;
}
