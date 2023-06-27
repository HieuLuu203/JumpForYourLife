using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 positionOffset;
    public static CameraScript Instance;

    private void Awake()
    {
        Instance = this;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void followPlayer()
    {
        float timer = 0;
        var step = speed * Time.deltaTime;
        Vector3 targetPosition = target.position + positionOffset;
        while (transform.position.y != targetPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, targetPosition.y, -5), step);
            timer += Time.deltaTime;
        }
    }
}
