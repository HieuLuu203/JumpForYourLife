using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class MovingScript : MonoBehaviour
{
    private float speed;
    Vector3 targetPos;

    [SerializeField] private GameObject ways;
    [SerializeField] private Transform[] wayPoints;
    private int pointIndex;
    private int pointCount;
    private int direction = 1;
    //Start is called before the first frame update


    void Awake()
    {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++) 
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
        
        GetComponent<BoxCollider2D>().enabled = true;
    }
    public void setPointindex(int point) { pointIndex = point; } 
        
    void Start()
    {
        
        pointCount = wayPoints.Length;
        
    }

    private void OnEnable()
    {
        pointIndex = WallSpawnScript.Instance.getCnt() % 2;
        speed = Random.Range(4, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }
    void OnCollisionExit2D (Collision2D collision)
    {
        GetComponentInChildren<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        collision.collider.transform.SetParent(null);
    
    }

    // Update is called once per frame
    void Update()
    {
        
        targetPos = wayPoints[pointIndex].transform.position;
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        //if (isLanded) player.transform.position = new Vector3(transform.position.x + distance, transform.position.y, 0);
        if (transform.position == targetPos)
        {
           NextPoint();
        }
  
    }

    void NextPoint ()
    {
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }
}
