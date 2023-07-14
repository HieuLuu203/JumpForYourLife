using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{

    private GameObject characterImage;
    private TextMeshProUGUI nameCharacter;
    [SerializeField] private Image bg;

    [SerializeField] private CharacterData data;

    private void Awake()
    {
        characterImage = GameObject.FindGameObjectWithTag("CharacterImage");
    }
    private void Start()
    {
        //nameCharacter.text = data.characterName;
        bg.sprite = data.sprite;
    }

    public void click()
    {
        characterImage.GetComponent<Image>().sprite = data.image;
        PlayerPrefs.SetInt("PlayerSkin", data.ID);
    }

}
