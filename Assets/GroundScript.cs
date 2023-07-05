using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    GameObject target;
    [SerializeField] private GameObject GameOverPanel;
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
        Time.timeScale = 0;
        target.SetActive(false);
        StartCoroutine("GameOver");
        Debug.Log("triggerd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(1);
        GameOverPanel.SetActive(true);
    }


}
