using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    private float timer;
    public static UI_Controller Instance;
    [SerializeField] private GameObject perfect;
    [SerializeField] private Sprite crackWall;
    [SerializeField] private Sprite multiple;
    [SerializeField] private Sprite number2;
    [SerializeField] private Sprite number3;
    [SerializeField] private Sprite number4;
    [SerializeField] private Sprite number5;
    [SerializeField] private Sprite number6;

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

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("score", ScoreManager.Instance.getScore());
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }   

    public Sprite getUI(string name)
    {
        if (name == "crackWall")
            return crackWall;
        else return null;
    }

}
