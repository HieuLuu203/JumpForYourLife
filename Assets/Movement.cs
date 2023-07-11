using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool isLanded;
    private bool isPerfect;
    [SerializeField] private Rigidbody2D myRigidbody;
    
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        isLanded = false;
        WallSpawnScript.Instance.spawnWall(5);
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
        if (Input.GetKeyDown(KeyCode.Space) == true && isLanded == true)
        {
            isPerfect = false;
            myRigidbody.velocity = Vector2.up * 2;
            //Debug.Log(myRigidbody.velocity.y);
            isLanded = false;
            //Debug.Log(isLanded);
            WallSpawnScript.Instance.spawnWall(1);
        }
    }
}
