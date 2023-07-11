using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    private TextMeshProUGUI nameCharacter;
    [SerializeField] private Image bg;

    [SerializeField] private CharacterData data;

    private void Start()
    {
        //nameCharacter.text = data.characterName;
        bg.sprite = data.sprite;
        Debug.Log(data.name);
    }

}
