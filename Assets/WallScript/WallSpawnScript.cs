using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private float heightOffSet;
    [SerializeField] private float depth;
    private float baseDepth;
    [SerializeField] private float speed;
    private int cnt;
    public static WallSpawnScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        baseDepth = depth;
    }
    public int getCnt () { return cnt; } 
    public void addCnt() { cnt++; }

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnWall(int time)
    {
        float lowestPoint = transform.position.x - heightOffSet;
        float highestPoint = transform.position.x + heightOffSet;
        for (int i = 1; i <= time; i++)
        {
            Instantiate(wall, new Vector3(Random.Range(lowestPoint, highestPoint), transform.position.y - depth, 0), transform.rotation);
            depth += baseDepth;
            cnt++;
        }
    }
}
