using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    GameObject target;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target.SetActive(false);
        Debug.Log("triggerd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
