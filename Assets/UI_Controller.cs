using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    private float timer;
    public static UI_Controller Instance;
    [SerializeField] private GameObject perfect, crackWall;
    
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        perfect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f) perfect.SetActive(false);
    }

    public void getPerfectUI()
    {
        perfect.SetActive(true);
        timer = 0;
    }
}
