using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character" )]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int ID;
    public Sprite sprite; // ava
    public Sprite image; // full 
}
