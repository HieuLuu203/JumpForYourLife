using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 positionOffset;
    private bool needUpdate;
    public static CameraScript Instance;

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
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Start is called before the first frame update
    private void Start()
    {
        needUpdate = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (needUpdate)
        {
            var step = speed * Time.deltaTime;
            Vector3 targetPosition = target.position + positionOffset;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, targetPosition.y, -5), step);
            if (transform.position == new Vector3(0, targetPosition.y, -5)) needUpdate = false;
        }
    }

    public void followPlayer()
    {
        needUpdate = true;
    }


}
