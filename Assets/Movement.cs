using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private CharacterData[] characters = new CharacterData[7];
    [SerializeField] private CharacterData character0;
    [SerializeField] private CharacterData character1;
    [SerializeField] private CharacterData character2;
    [SerializeField] private CharacterData character3;
    [SerializeField] private CharacterData character4;
    [SerializeField] private CharacterData character5;
    [SerializeField] private CharacterData character6;

    private void CharacterInit()
    {
        characters[0] = character0;
        characters[1] = character1;
        characters[2] = character2;
        characters[3] = character3;
        characters[4] = character4;
        characters[5] = character5;
        characters[6] = character6;
    }


    private bool isLanded;
    private bool isPerfect;
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        isLanded = false;
        CharacterInit();
        spriteRenderer.sprite = characters[PlayerPrefs.GetInt("PlayerSkin", 0)].image;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Middle Check")
        {
            UI_Controller.Instance.getPerfectUI();
            Debug.Log("Pf");
            isPerfect = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isLanded = true;
            CameraScript.Instance.followPlayer();
            if (isPerfect)
            {
                ScoreManager.Instance.addScore(2);
            }
            else
            {
                ScoreManager.Instance.addScore(1);
            }
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        isPerfect = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isLanded = true;
    }

    void OnCollisionExit2D (Collision2D collision) 
    { 
        //isLanded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isLanded == true && !IsOverUI())
        {
            isPerfect = false;
            myRigidbody.velocity = Vector2.up * 2;
            
            isLanded = false;
            
            WallSpawnScript.Instance.spawnWall(1);
        }
    }

    public static bool IsOverUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
